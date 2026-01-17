using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseProcessorApi.Models;
using CourseProcessorApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseProcessorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("process-json")]
        public async Task<IActionResult> ProcessJsonContent([FromBody] ProcessJsonRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.JsonContent))
                {
                    return BadRequest("Nội dung JSON không được để trống");
                }

                var courseData = await _courseService.ProcessJsonContentAsync(request.JsonContent);
                return Ok(courseData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadJsonFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Không có file nào được tải lên");
                }

                // Check file extension
                string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                if (fileExtension != ".txt" && fileExtension != ".json")
                {
                    return BadRequest("Chỉ chấp nhận file .txt hoặc .json");
                }

                var courseData = await _courseService.ProcessJsonFileAsync(file);

                // Return basic info about the processed file
                var response = new FileUploadResponse
                {
                    Success = true,
                    Message = "File đã được xử lý thành công",
                    FileName = file.FileName
                };

                return Ok(new { response, courseData });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("course/{id}")]
        public IActionResult GetCourse(string id)
        {
            // In a real application, this would fetch the course from a database
            return Ok($"API đang phát triển: Thông tin khóa học có ID {id} sẽ được hiển thị ở đây");
        }

        [HttpPost("export-text")]
        public async Task<IActionResult> ExportToText([FromBody] CourseData courseData)
        {
            try
            {
                string textContent = await _courseService.ExportCourseToTextAsync(courseData);
                return Ok(textContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("export-json")]
        public async Task<IActionResult> ExportToJson([FromBody] CourseData courseData)
        {
            try
            {
                string jsonContent = await _courseService.ExportCourseToJsonAsync(courseData);
                return Ok(jsonContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("download-text")]
        public async Task<IActionResult> DownloadText([FromBody] CourseData courseData)
        {
            try
            {
                string textContent = await _courseService.ExportCourseToTextAsync(courseData);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textContent);
                return File(bytes, "text/plain", "khoa_hoc_javascript.txt");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("download-json")]
        public async Task<IActionResult> DownloadJson([FromBody] CourseData courseData)
        {
            try
            {
                string jsonContent = await _courseService.ExportCourseToJsonAsync(courseData);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                return File(bytes, "application/json", "khoa_hoc_javascript.json");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("quiz-questions")]
        public IActionResult ExtractQuizQuestions([FromBody] CourseData courseData)
        {
            try
            {
                var quizQuestions = _courseService.ExtractQuizQuestions(courseData);
                return Ok(quizQuestions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}