using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGDAU.Advogado.Domain;
using SGDAU.Advogado.Domain.Models;
using SGDAU.Common;
using SGDAU.Unidade.Domain;
using SGDAU.Unidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TJSPApi;
using TJSPApi.Controllers;
using TJSPApi.Infrastructure;

namespace GraphQLRoutingTest
{
    [TestClass]
    public class RoutingUnitTest01
    {
        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IMemoryCache> mockMemoryCache;
        private Mock<IGraphQLSchemaCollection> graphQLSchemaCollection;
        private Mock<IUnidadeRepository> unidadeRepository;
        private Mock<IAdvogadoRepository> advogadoRepository;
        private Mock<IContextIronMountain> imContext;
        private Mock<ICacheEntry> cacheEntry;

        [TestInitialize]
        public void Initialize()
        {
            imContext = new Mock<IContextIronMountain>();
            unidadeRepository = new Mock<IUnidadeRepository>();
            unidadeRepository.Setup(
                setup => setup.GetDadosUnidade(It.IsAny<EFTJUnidade>())
            ).Returns(new EFTJUnidade() { 
                EFTJUnidadeID = 1,
                Description = "TESTE 01"
            });

            unidadeRepository.Setup(
                setup => setup.GetAllUnidades()
            ).Returns(new List<EFTJUnidade>()
            {
                new EFTJUnidade(){ EFTJUnidadeID = 1, Description = "TESTE 01" },
                new EFTJUnidade(){ EFTJUnidadeID = 2, Description = "TESTE 02" },
            });

            advogadoRepository = new Mock<IAdvogadoRepository>();
            advogadoRepository.Setup(
                setup => setup.PesquisarAdvogado(It.Is<EFTJAdvogado>(x => x.EFTJAdvogadoID == 1))
            ).Returns(new List<EFTJAdvogado>()
            {
                new EFTJAdvogado() { EFTJAdvogadoID = 1, Nome = "ADV 01" }
            });
            advogadoRepository.Setup(
                setup => setup.PesquisarAdvogado(It.Is<EFTJAdvogado>(x => x == null || x.EFTJAdvogadoID != 1))
            ).Returns(new List<EFTJAdvogado>()
            {
                new EFTJAdvogado() { EFTJAdvogadoID = 1, Nome = "ADV 01" },
                new EFTJAdvogado() { EFTJAdvogadoID = 2, Nome = "ADV 02" }
            });

            graphQLSchemaCollection = new Mock<IGraphQLSchemaCollection>();
            graphQLSchemaCollection.SetupGet(setup => setup.Items).Returns(new List<Type>() {
                typeof(IAdvogadoQuery),
                typeof(IUnidadeQuery)
            });

            mockServiceProvider = new Mock<IServiceProvider>();
            mockServiceProvider.Setup(
                setup => setup.GetService(typeof(IUnidadeQuery))
            ).Returns(new UnidadeQuery(new UnidadeService(imContext.Object, unidadeRepository.Object)));

            mockServiceProvider.Setup(
                setup => setup.GetService(typeof(IAdvogadoQuery))
            ).Returns(new AdvogadoQuery(new AdvogadoService(imContext.Object, advogadoRepository.Object)));

            mockServiceProvider.Setup(
                setup => setup.GetService(typeof(IGraphQLSchemaCollection))
            ).Returns(graphQLSchemaCollection.Object);
        }

        [TestCleanup]
        public void CleanUp()
        {
            mockServiceProvider = null;
            mockMemoryCache = null;
        }


        [TestMethod]
        public async Task TestMethod01()
        {
            var api = new GraphQLController(mockServiceProvider.Object, new MemoryCache(new MemoryCacheOptions()));
            var result = await api.Post(new TJSPApi.DTOs.GraphQLQuery()
            {
               
            });
            var badResult = result as BadRequestResult;
            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }


        [TestMethod]
        public async Task TestMethod02()
        {
            var api = new GraphQLController(mockServiceProvider.Object, new MemoryCache(new MemoryCacheOptions()));
            var result = await api.Post(new TJSPApi.DTOs.GraphQLQuery()
            {
                Query = "{unidade(id: 1){description}}"
            });
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}
