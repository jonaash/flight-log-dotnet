using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FlightLogNet.Models;
using FlightLogNet.Repositories;
using FlightLogNet.Repositories.Interfaces;
using Xunit;

namespace FlightLogNet.Tests.Repositories
{
	public class FlightRepositoryTests
	{
		private readonly IMapper mapper;

		public FlightRepositoryTests(IMapper mapper)
		{
			this.mapper = mapper;
		}

		private IFlightRepository CreateFlightRepository()
		{
			return new FlightRepository(mapper);
		}

		private void RenewDatabase()
		{
			TestDatabaseGenerator.CreateTestDatabase();
		}

		[Fact(Skip = "Not correctly implemented.")]
		public void GetFlightsOfTypeGlider_Return2Gliders()
		{
			// Arrange
			RenewDatabase();
			var flightRepository = CreateFlightRepository();

			// Act
			// TODO 2.2: Upravte volanou metodu, aby v�sledek vr�til pouze lety, kter� jsou kluz�ky.
			var result = flightRepository.GetAllFlights();

			// Assert
			Assert.True(result.Count == 2, "In test database is 2 gliders.");
		}

		[Fact(Skip = "Not correctly implemented.")]
		public void GetAirplanesInAir_ReturnFlightModels()
		{
			// Arrange
			RenewDatabase();
			var flightRepository = CreateFlightRepository();

			// Act
			// TODO 2.4: Dopl�te metodu repozit��e a odstra�te p�esko�en� testu (skip)
			IList<FlightModel> result = null;

			// Assert
			Assert.NotEmpty(result);
		}

		[Fact]
		public void GetReport_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			RenewDatabase();
			var flightRepository = CreateFlightRepository();

			// Act
			var result = flightRepository.GetReport();
			var flights = result.SelectMany(model => new[] { model.Glider, model.Towplane }).ToList();

			// Assert
			Assert.True(result.Count == 3, "In test database is 3 flight starts");
			Assert.True(flights[0] == null, "Last flight start should have null glider.");
		}
	}
}
