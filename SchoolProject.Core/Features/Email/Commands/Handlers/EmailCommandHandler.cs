using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Core.Features.Email.Commands.Handlers
{
    public class EmailCommandHandler : ResponsesHandler,
        IRequestHandler<SendEmailCommand, Responses<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IEmailServies _emailServies;

        #endregion

        #region Constructor
        public EmailCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IEmailServies emailServies) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _emailServies = emailServies;
        }


        #endregion

        #region Handle Functions
        public async Task<Responses<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var sendEmail = await _emailServies.SendEmailAsync(request.Email, request.Massage);
            if (sendEmail == "Failed")
                return BadRequest<string>("Failed");

            return Success<string>("Success");
        }
        #endregion
    }
}
