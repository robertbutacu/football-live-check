﻿using FootballLiveCheck.Business.Team.Commands;
using FootballLiveCheck.Business.Team.Models;
using FootballLiveCheck.Business.Team.Queries;
using FootballLiveCheck.Business.Team.QueryResults;
using FootballLiveCheck.CqrsCore.Dispatchers;
using FootballLiveCheck.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballLiveCheck.Service.Controllers
{
    [Route("api/teams")]
    public class TeamsController : BaseController
    {
        public TeamsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(
            commandDispatcher, queryDispatcher)
        {
        }

        [HttpPost("")]
        public IActionResult CreateTeam([FromBody] TeamModel teamModel)
        {
            var command = new CreateTeamCommand(teamModel);
            CommandDispatcher.Handle(command);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetAllTeams()
        {
            var query = new GetAllTeamsQuery();
            var result = QueryDispatcher.Retrive<GetAllTeamsQueryResult, GetAllTeamsQuery>(query);
            return Ok(result);
        }

        [HttpGet("{teamId}")]
        public IActionResult GetTeamById([FromRoute] int teamId)
        {
            var query = new GetTeamByIdQuery(teamId);
            var result = QueryDispatcher.Retrive<GetTeamByIdQueryResult, GetTeamByIdQuery>(query);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("byLeague/{leagueId}")]
        public IActionResult GetTeamsByLeagueId([FromRoute] int leagueId)
        {
            var query = new GetTeamsByLeagueIdQuery(leagueId);
            var result = QueryDispatcher.Retrive<GetTeamsByLeagueIdQueryResult, GetTeamsByLeagueIdQuery>(query);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }


        [HttpDelete("")]
        public IActionResult DeleteTeam([FromBody] TeamModel teamModel)
        {
            var command = new DeleteTeamCommand(teamModel);
            CommandDispatcher.Handle(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam([FromBody]TeamModel teamModel)
        {
            var command = new UpdateTeamCommand(teamModel);
            CommandDispatcher.Handle(command);
            return Ok();
        }



    }
}