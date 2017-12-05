﻿using AutoMapper;
using EnsureThat;
using FootballLiveCheck.Business.Team.QueryResults;
using FootballLiveCheck.CqrsCore.Queries;
using FootballLiveCheck.Domain.Repositories;

namespace FootballLiveCheck.Business.Team.QueryHandlers
{
    class GetTeamByIdQueryHandler : DatabaseHandler, IQueryHandler<GetTeamByIdQuery, GetTeamByIdQueryResult>
    {
        private readonly ITeamRepository teamRepository;

        public GetTeamByIdQueryHandler(IMapper mapper, ITeamRepository teamRepository) : base(mapper)
        {
            EnsureArg.IsNotNull(teamRepository);
            this.teamRepository = teamRepository;
        }

        public GetTeamByIdQueryResult Retrieve(GetTeamByIdQuery query)
        {
            return new GetTeamByIdQueryResult(this.teamRepository.Search(t => t.Id == query.Id));
        }
    }
}