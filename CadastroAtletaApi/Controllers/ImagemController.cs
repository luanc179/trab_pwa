using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadastroAtletaDll;

[ApiController]
[Route("api/[controller]")]
public class ImagemController : ControllerBase
{
    private readonly IWebHostEnvironment env;
    private readonly ILogger<ImagemController> logger;

    public ImagemController(IWebHostEnvironment env,
        ILogger<ImagemController> logger)
    {
        this.env = env;
        this.logger = logger;
    }

    [HttpGet("{entidade}/{id}")]
    public async Task<IActionResult> GetFile(string entidade, string id)
    {
        var fileName = "1.png";

        var dir = Path.Combine(env.ContentRootPath,
                            entidade, id);

        var path = Path.Combine(dir, fileName);

        if (!System.IO.File.Exists(path))
            return NotFound();

        //converting Pdf file into bytes array  
        var dataBytes = await System.IO.File.ReadAllBytesAsync(path);  
        //adding bytes to memory stream   
        var dataStream = new MemoryStream(dataBytes);

        return new FileStreamResult(dataStream, "image/png");
    }

    [HttpPost("{entidade}/{id}")]
    public async Task<ActionResult<IList<UploadResult>>> PostFile(string entidade, string id, [FromForm] IEnumerable<IFormFile> files)
    {
        var maxAllowedFiles = 1;
        long maxFileSize = 1024 * 1500;
        var filesProcessed = 0;
        var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
        List<UploadResult> uploadResults = new();

        foreach (var file in files)
        {
            var uploadResult = new UploadResult();
            
            var untrustedFileName = file.FileName;
            uploadResult.FileName = untrustedFileName;
            var trustedFileNameForDisplay =
                WebUtility.HtmlEncode(untrustedFileName);

            if (filesProcessed < maxAllowedFiles)
            {
                if (file.Length == 0)
                {
                    logger.LogInformation("{FileName} length is 0 (Err: 1)",
                        trustedFileNameForDisplay);
                    uploadResult.ErrorCode = 1;
                }
                else if (file.Length > maxFileSize)
                {
                    logger.LogInformation("{FileName} of {Length} bytes is " +
                        "larger than the limit of {Limit} bytes (Err: 2)",
                        trustedFileNameForDisplay, file.Length, maxFileSize);
                    uploadResult.ErrorCode = 2;
                }
                else
                {
                    try
                    {
                        var fileName = "1.png";
                        
                        var dir = Path.Combine(env.ContentRootPath,
                            entidade, id);

                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        var path = Path.Combine(dir, fileName);

                        await using FileStream fs = new(path, FileMode.Create);
                        await file.CopyToAsync(fs);

                        logger.LogInformation("{FileName} saved at {Path}",
                            trustedFileNameForDisplay, path);

                        uploadResult.Uploaded = true;
                        uploadResult.StoredFileName = fileName;
                    }
                    catch (IOException ex)
                    {
                        logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                            trustedFileNameForDisplay, ex.Message);

                        uploadResult.ErrorCode = 3;
                    }
                }

                filesProcessed++;
            }
            else
            {
                logger.LogInformation("{FileName} not uploaded because the " +
                    "request exceeded the allowed {Count} of files (Err: 4)",
                    trustedFileNameForDisplay, maxAllowedFiles);
                uploadResult.ErrorCode = 4;
            }

            uploadResults.Add(uploadResult);
        }

        return new CreatedResult(resourcePath, uploadResults);
    }
}
