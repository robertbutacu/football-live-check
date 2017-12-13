﻿using System;
using FluentAssertions;
using FootballLiveCheck.Business.Team.CommandHandlers;
using FootballLiveCheck.Business.Team.Commands;
using FootballLiveCheck.Domain.Repositories;
using FootballLiveCheck.Tests.Shared;
using FootballLiveCheck.Tests.Shared.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FootballLiveCheck.Business.Tests.Team.Commands
{
    [TestClass]
    public class DeleteTeamCommandHandlerTest : BaseCommandHandlerTest<DeleteTeamCommandHandler, DeleteTeamCommand, ITeamRepository>
    {
        private readonly Guid leagueId = new Guid("555F951D-C321-4ED2-8ADA-F0DEAB53C557");

        //  [TestMethod]
        //  public void Given_NumeMetoda_When_Conditie_Then_Should_Rezultat() { }

        [TestMethod]
        public void Given_Handle_When_PassedNullCommand_Then_Should_ThrowException()
        {
            Action act = () => SystemUnderTest.Handle(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Given_Handle_When_PassedValidCommand_Then_Should_DeleteTeamFromRepository()
        {
            ExecuteCommand();
        }

        protected override DeleteTeamCommandHandler CreateSystemUnderTest()
        {
            return new DeleteTeamCommandHandler(MapperMock.Object, RepositoryMock.Object);
        }

        protected override DeleteTeamCommand CreateCommand()
        {
            var model = TeamFactory.GetModel("TeamTestName", leagueId, 20);
            return new DeleteTeamCommand(model);
        }
    }
}