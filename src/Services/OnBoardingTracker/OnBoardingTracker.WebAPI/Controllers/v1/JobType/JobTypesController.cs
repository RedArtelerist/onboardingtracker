using App.Metrics;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardingTracker.Application.JobTypes.Commands;
using OnBoardingTracker.Application.JobTypes.Models;
using OnBoardingTracker.Application.JobTypes.Queries;
using OnBoardingTracker.WebApi.Infrastructure.Metrics;
using OnBoardingTracker.WebAPI.Controllers;
using System.Threading.Tasks;

namespace OnBoardingTracker.WebApi.Controllers.v1.JobType
{
    [ApiVersion("1.0")]
    public class JobTypesController : ApiController
    {
        private readonly IMetrics metrics;

        public JobTypesController(IMediator mediator, IMetrics metrics)
            : base(mediator)
        {
            this.metrics = metrics;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobTypeList))]
        public async Task<ActionResult> GetJobTypes()
        {
            return Ok(await Mediator.Send(new GetJobTypes()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobTypeModel))]
        public async Task<ActionResult> GetJobTypeById(int id)
        {
            return Ok(await Mediator.Send(new GetJobTypeById { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(JobTypeModel))]
        public async Task<ActionResult> CreateJobType([FromBody] CreateJobType createJobType)
        {
            var createdJobType = await Mediator.Send(createJobType);
            metrics.Measure.Counter.Increment(MetricsRegistry.CreatedJobType);
            return CreatedAtAction(nameof(GetJobTypeById), new { id = createdJobType.Id }, createdJobType);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobTypeModel))]
        public async Task<ActionResult> UpdateJobType([FromBody] UpdateJobType model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobTypeModel))]
        public async Task<ActionResult> DeleteJobType(int id)
        {
            return Ok(await Mediator.Send(new DeleteJobType { Id = id }));
        }
    }
}
