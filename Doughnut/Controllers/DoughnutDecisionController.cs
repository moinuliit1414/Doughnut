using Doughnut.Dto;
using Doughnut.Services.Contracts;
using Doughnut.Types.Exceptions;
using Doughnut.Types.Requests;
using Doughnut.Types.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoughnutDecisionController:ControllerBase
    {
        private readonly ILogger<DoughnutDecisionController> _logger;
        IDecisionService _decisionService;
        public DoughnutDecisionController(ILogger<DoughnutDecisionController> logger, IDecisionService decisionService)
        {
            _decisionService = decisionService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                string question = _decisionService.GetFirstQuestion();
                return Ok(new SuccessResponse<dynamic>(new
                {
                    Statement = question,
                    //Node = new Object(),
                    Answers = new List<bool>()
                })); ;
            }
            catch (NodeNotFoundException ex) {
                return Ok(new ErrorResponse(new NodeNotFoundException()));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAnswer answers)
        {
            List<bool> values = answers.answers.ToList();
            if (values == null || values.Count <= 0) {
                return BadRequest(new ErrorResponse(new DoughnutException("Parameter validation failed!!")));
            }
            try
            {
                INode node = _decisionService.GetClildTree(values);
                if (node.LeafN == null && node.LeafY == null) {
                    //Return full tree with selected mark if all answer are given.
                    return Ok(new SuccessResponse<dynamic>(new
                    {
                        //Statement = node.Statement,
                        Node = _decisionService.GetTraversedTree(answers.answers),
                        Answers = answers.answers
                    }));
                }
                return Ok(new SuccessResponse<dynamic>(new
                {
                    Statement = node.Statement,
                    Answers = answers.answers
                }));

            }
            catch (NodeNotFoundException exception)
            {
                //Return Bad requers if invalid answer are given.
                return BadRequest(new ErrorResponse(exception));
            }
            catch (Exception ex) {
                //will change later.
                return BadRequest(new ErrorResponse(new DoughnutException()));
            }
        }
    }
}
