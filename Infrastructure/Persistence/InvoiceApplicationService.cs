using Framework;
using System;
using System.Threading.Tasks;
using Domain.Repository;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class InvoiceApplicationService : IApplicationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateService _dateService;

        public InvoiceApplicationService(
            IAuthorizationRepository authorizationRepository,
            IInvoiceRepository invoiceRepository,
            IUnitOfWork unitOfWork,
            IDateService dateService)
        {
            _authorizationRepository = authorizationRepository;
            _invoiceRepository = invoiceRepository;            
            _unitOfWork = unitOfWork;
            _dateService = dateService;
        }

        public Task Handle(object command)
        {
            switch (command)
            {
                case Infrastructure.Commands.V1.Invoice.CreateInvoice e:
                    return HandleCreateInvoice(e);
                case Infrastructure.Commands.V1.Invoice.ReturnInvoice e:
                    return HandleReturnInvoice(e);
            }
            return Task.CompletedTask;
        }

        private async Task HandleReturnInvoice(Commands.V1.Invoice.ReturnInvoice c)
        {
            Invoice invoiceToBeReturned = null;
            try
            {
                invoiceToBeReturned = await _invoiceRepository.Load(new Domain.ValueObject.InvoiceGuid(c.InvoiceId));
            }
            catch (Exception e)
            {
                if (invoiceToBeReturned == null)
                    throw new ArgumentException("The book to be returned doesn't exist", e);
            }

            try
            {
                //_lendRepository.Update(bookLend);
                _invoiceRepository.Update(invoiceToBeReturned);
                await _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new ArgumentException("There was a problem saving the information", e);
            }
        }

          private async Task HandleCreateInvoice(Infrastructure.Commands.V1.Invoice.CreateInvoice c)
        {
            Invoice newInvoice = null;
            try
            {
                newInvoice =
                new Invoice(c.InvoiceNumber, c.ClientName, c.TaxPayerIdentificationNumber, c.AuthorizationId);
            }
            catch (Exception e)
            {
                if (newInvoice == null)
                    throw new ArgumentException("There was a problem creating the Invoice");
            }

            try
            {
                await _invoiceRepository.Add(newInvoice);
                await _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new Exception("Could not save the new Invoice", e);
            }
        }
    }
}

   
