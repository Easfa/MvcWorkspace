using Microsoft.AspNetCore.Mvc;

namespace MvcWorkspace.Controllers
{
    public class ReturnTypeController : Controller

    {

        private readonly IWebHostEnvironment _IhostingEnviornment;



        public ReturnTypeController(IWebHostEnvironment IhostingEnviornment)

        {

            _IhostingEnviornment = IhostingEnviornment;

        }



        #region :: Status Code Result ::

        /// 1.

        /// <summary>

        /// This is a StatusCodeResult. When executed, it will provide an empty StatusCode 200 OK result.

        /// </summary>

        /// <return></return>

        public IActionResult OKResult()

        {

            return Ok();

        }



        /// 2.

        /// <summary>

        /// returns a created (201) response with a location header.

        /// This indicates the request has been fulfilled and has resulted 

        /// in one or more new resources being created.

        /// </summary>

        /// <returns></returns>        

        public IActionResult CreatedResult()

        {

            return Created("http://example.org/myitem&quot;" , new { name = "newitem" });

        }



        /// 3.

        /// <summary>

        /// Result returns 204 status code

        /// </summary>

        /// <returns></returns>

        public IActionResult NoContentResult()

        {

            return NoContent();

        }



        /// 4.

        /// <summary>

        /// An ObjectResult, When executed, will produce a Bad Request (400) response.

        /// It indicates a bad request by the user.

        /// It does not take any argument.

        /// </summary>

        /// <returns></returns>

        public IActionResult BadRequestResult()

        {

            return BadRequest();

        }



        /// 5.

        /// <summary>

        /// UnauthorizedResult returns 401 status code, its difference with 

        /// ChallengeResult is that it just returns an status and doesn't

        /// do anything else.

        /// In contrast with its counertpart that has many options for 

        /// redirecting the user and options related to asp.net core Identity.

        /// </summary>

        /// <returns></returns>

        public IActionResult UnauthorizeResult()

        {

            return Unauthorized();

        }



        /// 6.

        /// <summary>

        /// Represent a StatusCodeResult that when executed, will produce

        /// a Not Found (404) response.

        /// </summary>

        /// <returns></returns>        

        public IActionResult NotFoundResult()

        {

            return NotFound();

        }



        /// 7.

        /// <summary>

        /// This action result returns 415 status code, which means server cannot 

        /// continue to process the request with the given payload.

        /// It doing this by inspecting the content-type or content-Ecoding

        /// of the current request or inspecting the incoming data directly.

        /// </summary>

        /// <returns></returns>

        public IActionResult UnSupportedMediaTypeResult()

        {

            return new UnsupportedMediaTypeResult();

        }



        #endregion



        #region :: Status Code with Object Result ::



        /// 8.

        /// <summary>

        /// An ObjectResult, when executed, perform content negotiation,

        /// formats the entity body, and will produce a status 200OK response

        /// if negotiation and formatting succeed.

        /// </summary>

        /// <returns></returns>



        public IActionResult OKObjectResult()

        {

            var result = new OkObjectResult(new

            { message = "200 OK ", CurrentDate = DateTime.Now });

            return result;

        }



        /// 9.

        /// <summary>

        /// CreatedAtActionResult that returns a Created 201 response with location header.

        /// </summary>

        /// <returns></returns>

        public IActionResult CreatedObjectResult()

        {

            var result = new CreatedAtActionResult("createdobjectresult",

                "statuscodeobjects", "",

                new { message = "201 Created", current = DateTime.Now });

            return result;

        }



        /// 10.

        /// <summary>

        /// This is similar to BadrequestResult, with the difference that

        /// it can pass an object or a ModelStateDictionary containing the

        /// details regarding the error.

        /// </summary>

        /// <returns></returns>        

        public IActionResult BadRequestObjectResult()

        {

            var result = new BadRequestObjectResult(new

            { message = "400 Bad Request", currentDate = DateTime.Now });

            return result;

        }



        /// 11.

        /// <summary>

        /// This is similar to NotFoundResult, with the difference that

        /// it can pass an object with 404 response.

        /// </summary>

        /// <returns></returns> 

        public IActionResult NotFoundObjectResult()

        {

            var result = new NotFoundObjectResult(new

            { messgae = "404 Not Found", currentDate = DateTime.Now });

            return result;

        }

        #endregion



        #region :: Redirect Results ::



        /// 12.

        /// <summary>

        /// Redirect to specified string URL with permanent 301 property set to false

        /// </summary>

        /// <returns></returns>

        public IActionResult RedirectResult()

        {

            return Redirect("https://www.google.com/&quot");

        }



        /// 13.

        /// <summary>

        /// Redirect to specified URL is its Local URL

        /// if not it will throw an exception, permanent 301 property set to false

        /// </summary>

        /// <returns></returns>

        public IActionResult LocalRedirectResult()

        {

            return LocalRedirect("/redirects/target");

        }



        /// 14.

        /// <summary>

        /// RedirectTOActionresult can redirect us to an action.

        /// It takes the action name, controller name, and route value.

        /// </summary>

        /// <returns></returns>

        public IActionResult RedirectToActionResult()

        {

            return RedirectToAction("target", "Appointment");

        }



        #endregion



        #region :: File Result ::



        /// 15.

        /// <summary>

        /// Returns the file content as pdf content

        /// </summary>

        /// <returns></returns>

        public IActionResult FileResult()

        {

            return File("~/downloads/pdf-sample.pdf", "application/pdf");

        }



        /// 16.

        /// <summary>

        /// Returns the file as an array of bytes as you see in the FileContentActionResult.

        /// </summary>

        /// <returns></returns>

        public IActionResult FileContentResult()

        {

            //Get the byte array for the document

            var pdfBytes = System.IO.File.ReadAllBytes

                ("wwwroot/downloads/pdf-sample.pdf");

            //FileContentResult needs a byte array and returns a file

            //with the specified content type

            return new FileContentResult(pdfBytes, "application/pdf");

        }



        /// 17.

        /// <summary>

        /// Use virtualFileResult if you want to read a file from

        /// a virtual address and return it

        /// </summary>

        /// <returns></returns>

        public IActionResult VirtualFileResult()

        {

            //Path given to the VirtualFileResult are relative

            // to the wwwroot folder.

            return new VirtualFileResult("/downloads/pdf-sample.pdf", "application/pdf");

        }



        /// 18.

        /// <summary>

        /// Use PhysicalFileResult to read a file from a physical address and return it

        /// </summary>

        /// <returns></returns>

        public IActionResult PhysicalFileResult()

        {

            return new PhysicalFileResult(_IhostingEnviornment.ContentRootPath

                + "/wwwroot/downloads/pdf-sample.pdf", "application/pdf");

        }



        #endregion



        #region :: Content Result ::



        /// 19.

        /// <summary>

        /// It renders a specified view to the response stream.

        /// </summary>

        /// <returns></returns>

        public IActionResult Index()

        {

            return View();

        }



        /// 20.

        /// <summary>

        /// It renders a specified partial view to the response stream.

        /// </summary>

        /// <returns></returns>

        public IActionResult PartialViewResult()

        {

            return PartialView();

        }



        /// 21.

        /// <summary>

        /// Return JsonResult (Javascript Object Notation result)

        /// </summary>

        /// <returns></returns>

        public IActionResult JsonResult()

        {

            return Json(new

            {

                message = "This is a json result",

                currentDate = DateTime.Now

            });

        }



        /// 22.

        /// <summary>

        /// It displays the response stream without requiring a view

        /// </summary>

        /// <returns></returns>

        public IActionResult ContentResult()

        {

            return Content("Here's the content result message");

        }



        #endregion

    }
}
