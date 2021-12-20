using Autofac.Extras.Moq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDGAApi.Net.Models.Base;
using PDGAApi.Net.Models.Course;
using PDGAApi.Net.Models.Event;
using PDGAApi.Net.Models.Player;
using PDGAApi.Net.Models.PlayerStatistics;
using System.Linq;
using System.Threading.Tasks;

namespace PDGAApi.Net.Tests
{
    [TestClass]
    public class PDGATests
    {
        private readonly string userName;
        private readonly string password;

        public PDGATests()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<PDGATests>()
                .Build();
            userName = config["PDGA:UserName"];
            password = config["PDGA:Password"];
        }

        [TestMethod]
        public void PDGA_Creates_Successfully()
        {
            using var mock = AutoMock.GetLoose();

            using var service = new PDGA(new PDGARestConfig
            {
                UserName = userName,
                Password = password
            });

            service.Should().NotBeNull();
        }

        [TestMethod]
        [DataRow(124876, "Tristan", "Goetz")]
        [DataRow(123456, "Connor", "Martineau")]
        [DataRow(100000, "Ryan", "Quinlan")]
        public async Task PlayerSearchAsync_ReturnsCorrectPlayer_WithPdgaNumber(int pdgaNumber, string firstName, string lastName)
        {
            using var mock = AutoMock.GetLoose();

            using var service = new PDGA(new PDGARestConfig
            {
                UserName = userName,
                Password = password
            });

            var resp = await service.PlayerSearchAsync(new PlayerSearchParameters
            {
                PDGANumber = pdgaNumber
            });

            resp.Should().NotBeNullOrEmpty();

            var firstPlayer = resp.FirstOrDefault();

            firstPlayer.Should().NotBeNull();
            firstPlayer.FirstName.Should().Be(firstName);
            firstPlayer.LastName.Should().Be(lastName);
            firstPlayer.PDGANumber.Should().Be(pdgaNumber);
        }

        [TestMethod]
        [DataRow(124876, "Tristan", "Goetz")]
        [DataRow(123456, "Connor", "Martineau")]
        [DataRow(100000, "Ryan", "Quinlan")]
        public async Task PlayerStatisticsAsync_ReturnsCorrectPlayer_WithPdgaNumber(int pdgaNumber, string firstName, string lastName)
        {
            using var mock = AutoMock.GetLoose();

            using var service = new PDGA(new PDGARestConfig
            {
                UserName = userName,
                Password = password
            });

            var resp = await service.PlayerStatisticsAsync(new PlayerStatisticsParameters
            {
                PDGANumber = pdgaNumber
            });

            resp.Should().NotBeNullOrEmpty();
            resp.All(p => p.FirstName.Equals(firstName)).Should().BeTrue();
            resp.All(p => p.LastName.Equals(lastName)).Should().BeTrue();
            resp.All(p => p.PDGANumber.Equals(pdgaNumber)).Should().BeTrue();
        }

        [TestMethod]
        [DataRow(50985, "NADGT Exclusive @ Holloway", "Lakeland")]
        [DataRow(47877, "DGPT - Las Vegas Challenge presented by Innova", "Henderson")]
        public async Task EventSearchAsync_ReturnsCorrectEvent_WithTournamentId(int tournamentId, string tournamentName, string city)
        {
            using var mock = AutoMock.GetLoose();

            using var service = new PDGA(new PDGARestConfig
            {
                UserName = userName,
                Password = password
            });

            var resp = await service.EventSearchAsync(new EventSearchParameters
            {
                TournamentId = tournamentId
            });

            resp.Should().NotBeNullOrEmpty();
            resp.All(p => p.TournamentId.Equals(tournamentId)).Should().BeTrue();
            resp.All(p => p.TournamentName.Equals(tournamentName)).Should().BeTrue();
            resp.All(p => p.City.Equals(city)).Should().BeTrue();
        }

        [TestMethod]
        [DataRow(2146, "Bluemont Park", "Arlington")]
        [DataRow(2309, "Stephens County/Rose Lane Disc Golf Course", "Toccoa")]
        public async Task CourseSearchAsync_ReturnsCorrectEvent_WithCourseId(int courseId, string courseName, string courseCity)
        {
            using var mock = AutoMock.GetLoose();

            using var service = new PDGA(new PDGARestConfig
            {
                UserName = userName,
                Password = password
            });

            var resp = await service.CourseSearchAsync(new CourseSearchParameters
            {
                CourseId = courseId
            });

            resp.Should().NotBeNullOrEmpty();
            resp.All(p => p.CourseId.Equals(courseId)).Should().BeTrue();
            resp.All(p => p.CourseName.Equals(courseName)).Should().BeTrue();
            resp.All(p => p.City.Equals(courseCity)).Should().BeTrue();
        }
    }
}
