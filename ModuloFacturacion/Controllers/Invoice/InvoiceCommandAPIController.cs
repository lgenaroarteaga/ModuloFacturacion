using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Serilog;
using System;
using Framework;


namespace ModuloFacturacion.Controllers.Invoice
{
    [Route("api/invoice")]
    public class InvoiceCommandAPIController : Controller
    {
        private readonly IApplicationService _applicationService;
        private static readonly ILogger _log = Serilog.Log.ForContext<InvoiceCommandAPIController>();

        public InvoiceCommandAPIController(IApplicationService applicationService)
            => _applicationService = applicationService;

        // POST api/<controller>
        [Route("create")]
        [HttpPost]
        public Task<IActionResult> Post([FromBody]Infrastructure.Commands.V1.Invoice.CreateInvoice request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, _log);

       
        [Route("return")]
        [HttpPost]
        public Task<IActionResult> Post([FromBody]Infrastructure.Commands.V1.Invoice.ReturnInvoice request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, _log);
    }
}
