using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.MarketModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ObstacleModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ShipModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceEnvironmentModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class RouteTests
{
    public class Tests
    {
        private readonly Exchange _exchange = new Exchange(
            new MarketAttitude(typeof(ActivePlasma), new Money(5)),
            new MarketAttitude(typeof(GravitoMatter), new Money(35)));

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void RouteInHighDensitySpace(System.Type expectedResult)
        {
            var ship = new PleasureShuttle();
            var spaceEnvironment = new NormalSpace(new LightHours(10));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(ship, new ActivePlasma(1000), new GravitoMatter(1000));
            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.CrewDead))]
        public void AntimatterFlashInSubspaceChannelFails(System.Type expectedResult)
        {
            var ship = new Valkas(false);
            var spaceEnvironment = new DenseSpaceNebula(new LightHours(10), new AntimatterFlash());
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(ship, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipLost))]
        public void StellaShipLost(System.Type expectedResult)
        {
            var ship = new Stella(false);
            var spaceEnvironment = new DenseSpaceNebula(new LightHours(10000), new AntimatterFlash());
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(ship, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipBrokenDown))]
        public void PleasureShuttleBrokenDown(System.Type expectedResult)
        {
            var ship = new PleasureShuttle();
            var spaceEnvironment = new NitrogenParticleNebula(new LightHours(10), new SpaceWhalePopulation(1));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(ship, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void AntimatterFlashInSubspaceChannelTrue(System.Type expectedResult)
        {
            var ship = new Valkas(true);
            var spaceEnvironment = new DenseSpaceNebula(new LightHours(10), new AntimatterFlash());
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(ship, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipBrokenDown))]
        public void SpaceWhaleValkas(System.Type expectedResult)
        {
            var valkas = new Valkas(true);
            var spaceEnvironment = new NitrogenParticleNebula(new LightHours(1), new SpaceWhalePopulation(1));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(valkas, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void SpaceWhaleAugur(System.Type expectedRouteResult)
        {
            var augur = new Augur(true);
            var spaceEnvironment = new NitrogenParticleNebula(new LightHours(1), new SpaceWhalePopulation(1));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedRouteResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipBrokenDown))]
        public void SpaceWhaleMeridian(System.Type expectedResult)
        {
            var meridian = new Meridian(true);
            var spaceEnvironment = new NitrogenParticleNebula(new LightHours(10), new SpaceWhalePopulation(1));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(meridian, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(expectedResult, result.GetType());
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void PleasureShuttleAndVaklasInNormalSpace(System.Type expectedResult)
        {
            var pleasureShuttle = new PleasureShuttle();
            var valkas = new Valkas(false);
            var ships = new Collection<IShip> { pleasureShuttle, valkas };
            var spaceEnvironment = new NormalSpace(new LightHours(100));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            ExpeditionResult result =
                new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships);
            Assert.Equal(expectedResult, result.GetType());
            Assert.True(result.Ship is Valkas);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void PleasureShuttleAndValkasInNitrogenParticleNebula(
            System.Type expectedResult)
        {
            var pleasureShuttle = new PleasureShuttle();
            var vaklas = new Valkas(true);
            var ships = new Collection<IShip> { vaklas, pleasureShuttle };
            var spaceEnvironment = new NitrogenParticleNebula(new LightHours(80));
            var env = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(env);
            ExpeditionResult result =
                new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships);
            Assert.Equal(expectedResult, result.GetType());
            Assert.True(result.Ship is Valkas);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void PleasureShuttleAndStellaInDenseSpaceNebula(
            System.Type expectedResult)
        {
            var pleasureShuttle = new PleasureShuttle();
            var meridian = new Stella(true);
            var ships = new Collection<IShip>
            {
                pleasureShuttle, meridian,
            };
            var spaceEnvironment = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(environments);
            ExpeditionResult result =
                new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships);
            Assert.Equal(expectedResult, result.GetType());
            Assert.True(result.Ship is Stella);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void AugurAndStellaDenseSpaceNebula(
            System.Type expectedResult)
        {
            var augur = new Augur(true);
            var stella = new Stella(true);
            var ships = new Collection<IShip> { augur, stella };
            var spaceEnvironment = new DenseSpaceNebula(new LightHours(200), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(environments);
            ExpeditionResult result =
                new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships);
            Assert.Equal(expectedResult, result.GetType());
            Assert.True(result.Ship is Stella);
        }

        [Fact]
        public void AugurAndStellaNoAvailableShips()
        {
            var augur = new Augur(false);
            var stella = new Stella(false);
            var ships = new Collection<IShip> { augur, stella };
            var spaceEnvironment = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { spaceEnvironment };
            var route = new Route(environments);
            IShip? optimalShip = new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships).Ship;
            Assert.True(optimalShip is null);
        }

        [Fact]
        public void AugurWithPhotonDeflectorAndPleasureShuttleMixedEnvironmentsOptimalShip()
        {
            var augur = new Augur(true);
            var pleasureShuttle = new PleasureShuttle();
            var ships = new Collection<IShip> { augur, pleasureShuttle };
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var normalSpace = new NormalSpace(new LightHours(40), new Meteor());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula, normalSpace };
            var route = new Route(environments);
            IShip? optimalShip = new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships).Ship;
            Assert.True(optimalShip is Augur);
        }

        [Theory]
        [InlineData(true)]
        public void AugurWithoutPhotonDeflectorAndPleasureShuttleMixedEnvironmentsOptimalShip(bool expectedResult)
        {
            var augur = new Augur(false);
            var pleasureShuttle = new PleasureShuttle();
            var ships = new Collection<IShip> { augur, pleasureShuttle };
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var normalSpace = new NormalSpace(new LightHours(40), new Meteor());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula, normalSpace };
            var route = new Route(environments);
            IShip? optimalShip = new ChoseTheBestShipByFuelAndTime(route, _exchange).FindOptimalShip(ships).Ship;
            Assert.Equal(optimalShip is null, expectedResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipLost))]
        public void PleasureShuttleInDenseSpaceNebula(
            System.Type expectedRouteResult)
        {
            var pleasureShuttle = new PleasureShuttle();
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40));
            var normalSpace = new NormalSpace(new LightHours(40));
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula, normalSpace };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult = expedition
                .PassRoute(pleasureShuttle, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipLost))]
        public void MeridianInDenseSpaceNebula(System.Type expectedType)
        {
            var meridian = new Meridian(false);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40));
            var normalSpace = new NormalSpace(new LightHours(40));
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula, normalSpace };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            ExpeditionResult result = expedition.PassRoute(meridian, new ActivePlasma(1000), new GravitoMatter(1000));

            Assert.Equal(result.GetType(), expectedType);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.ShipLost))]
        public void AugurInDenseSpaceNebula(
            System.Type expectedRouteResult)
        {
            var augur = new Augur(false);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(120));
            var normalSpace = new NormalSpace(new LightHours(40));
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula, normalSpace };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void AugurWithPhotonDeflectorAntimatterFlash(
            System.Type expectedRouteResult)
        {
            var augur = new Augur(true);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.CrewDead))]
        public void AugurWithoutPhotonDeflectorAntimatterFlash(
            System.Type expectedRouteResult)
        {
            var augur = new Augur(false);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void StellaWithPhotonDeflectorAntimatterFlash(
            System.Type expectedRouteResult)
        {
            var augur = new Stella(true);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.CrewDead))]
        public void StellaWithoutPhotonDeflectorAntimatterFlash(
            System.Type expectedRouteResult)
        {
            var augur = new Stella(false);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.Success))]
        public void ValkasWithPhotonDeflectorAntimatterFlash(
            System.Type expectedRouteResult)
        {
            var augur = new Valkas(true);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();
            Assert.Equal(expectedRouteResult, routeResult);
        }

        [Theory]
        [InlineData(typeof(ExpeditionResult.CrewDead))]
        public void ValkasWithoutPhotonDeflectorAntimatterFlash(
            System.Type expectedRouteResult)
        {
            var augur = new Valkas(false);
            var denseSpaceNebula = new DenseSpaceNebula(new LightHours(40), new AntimatterFlash());
            var environments = new Collection<ISpaceEnvironment> { denseSpaceNebula };
            var route = new Route(environments);
            var expedition = new Expedition(route, _exchange);
            System.Type routeResult =
                expedition.PassRoute(augur, new ActivePlasma(1000), new GravitoMatter(1000)).GetType();

            Assert.Equal(expectedRouteResult, routeResult);
        }
    }
}