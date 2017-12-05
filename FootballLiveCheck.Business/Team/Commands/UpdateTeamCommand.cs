﻿using EnsureThat;
using FootballLiveCheck.Business.Team.Models;
using FootballLiveCheck.CqrsCore.Commands;

namespace FootballLiveCheck.Business.Team.Commands
{
    class UpdateTeamCommand : ICommand
    {
        public UpdateTeamCommand(TeamModel teamModel)
        {
            EnsureArg.IsNotNull(teamModel);
            TeamModel = teamModel;
        }

        public TeamModel TeamModel { get; }
    }
}
