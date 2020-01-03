/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.Explorer;
using Dev2.Common.Interfaces.Hosting;
using Dev2.Common.Interfaces.Infrastructure;
using Dev2.Common.Interfaces.Runtime;
using Dev2.Common.Interfaces.Security;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Common.Wrappers;
using Dev2.Explorer;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.Interfaces;
using Dev2.Services.Security;
using NUnit.Framework;
using Moq;
using Warewolf.UnitTestAttributes;


namespace Dev2.Tests.Runtime.Hosting
{
    [TestFixture]
    [Category("Runtime Hosting")]
    public class ServerExplorerRepositoryTests
    {
        class Config : ServerExplorerRepository.IConfig
        {
            public Config(IResourceCatalog resourceCatalog, IExplorerItemFactory explorerItemFactory, IDirectory directoryWrapper, IFile fileWrapper, ITestCatalog testCatalog)
            {
                ResourceCatalog = resourceCatalog;
                ExplorerItemFactory = explorerItemFactory;
                DirectoryWrapper = directoryWrapper;
                FileWrapper = fileWrapper;
                TestCatalog = testCatalog;
            }

            public IAuthorizationService AuthorizationService { get; set; }
            public IResourceCatalog ResourceCatalog { get; set; }
            public ITestCatalog TestCatalog { get; set; }
            public IExplorerItemFactory ExplorerItemFactory { get; set; }
            public IVersionStrategy VersionStrategy { get; set; }
            public IDirectory DirectoryWrapper { get; set; }
            public IFile FileWrapper { get; set; }
            public IFilePath FilePathWrapper { get; set; }
            public string WorkspacePath { get; set; }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertCatalogueNull_ExpectException()
        {
             //------------Setup for test--------------------------

            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();

            
            var sync = new Mock<IExplorerRepositorySync>();
            var testCatalogue = new Mock<ITestCatalog>();
            new ServerExplorerRepository(new Config(null, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Author("Nkosinathi Sangweni")]
        [Category("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertTestCatalogueNull_ExpectException()
        {
             //------------Setup for test--------------------------

            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();

            
            var sync = new Mock<IExplorerRepositorySync>();
            new ServerExplorerRepository(new Config(null, factory.Object, dir.Object, new FileWrapper(), null), sync.Object);
            

        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertfactoryNull_ExpectException()
        {
             //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var dir = new Mock<IDirectory>();

            
            var sync = new Mock<IExplorerRepositorySync>();
            var testCatalogue = new Mock<ITestCatalog>();
            new ServerExplorerRepository(new Config(catalogue.Object, null, dir.Object, new FileWrapper(),testCatalogue.Object), sync.Object);
            

        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertDirectoryNull_ExpectException()
        {
             //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();


            
            var sync = new Mock<IExplorerRepositorySync>();
            var testCatalogue = new Mock<ITestCatalog>();
            new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, null, new FileWrapper(),testCatalogue.Object), sync.Object);
            

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_Load")]
        public void ServerExplorerRepository_Load_AssertRootLevelIsFolder_ExpectFolder()
        {
             //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                "Folder",
                new List<IExplorerItem>
                    {
                        new ServerExplorerItem("Services", Guid.NewGuid(), "Folder",
                                               new List<IExplorerItem>(), Permissions.Administrator, "bob"),
                        new ServerExplorerItem("Bobs", Guid.NewGuid(), "Folder", new List<IExplorerItem>(),
                                               Permissions.Administrator, "bob")

                    }
                , Permissions.Administrator, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var testCatalogue = new Mock<ITestCatalog>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            //------------Execute Test---------------------------
            var root = serverExplorerRepository.Load(Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Folder", root.ResourceType);
            Assert.AreEqual(2, root.Children.Count);
            Assert.AreEqual("Services", root.Children.First().DisplayName);
            Assert.AreEqual("Bobs", root.Children[1].DisplayName);
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_Load")]
        public void ServerExplorerRepository_LoadFiltered_AssertRootLevelIsFolder_ExpectFolder()
        {
              //------------Setup for test--------------------------
              var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                "Folder",
                new List<IExplorerItem>
                    {
                        new ServerExplorerItem("Services", Guid.NewGuid(), "Folder",
                                               new List<IExplorerItem>(), Permissions.Contribute, "bob"),
                        new ServerExplorerItem("Bobs", Guid.NewGuid(), "Folder", new List<IExplorerItem>(),
                                               Permissions.Contribute, "bob")

                    }
                , Permissions.Contribute, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem("Folder", It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            //------------Execute Test---------------------------
            var root = serverExplorerRepository.Load("Folder", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Folder", root.ResourceType);
            Assert.AreEqual(root.Permissions, Permissions.Contribute);
            factory.Verify(a => a.CreateRootExplorerItem("Folder", It.IsAny<string>(), It.IsAny<Guid>()));
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_Load")]
        public void ServerExplorerRepository_Load_FilteredTypeAndPath_AssertRootLevelIsFolder_ExpectFolder()
        {
             //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var testCatalogue = new Mock<ITestCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                "Folder",
                new List<IExplorerItem>
                    {
                        new ServerExplorerItem("Services", Guid.NewGuid(), "Folder",
                                               new List<IExplorerItem>(), Permissions.Administrator, "bob"),
                        new ServerExplorerItem("Bobs", Guid.NewGuid(), "Folder", new List<IExplorerItem>(),
                                               Permissions.Administrator, "bob")

                    }
                , Permissions.Administrator, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem("Folder", It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            //------------Execute Test---------------------------
            var root = serverExplorerRepository.Load("Folder", "monkey");
            //------------Assert Results-------------------------
            Assert.AreEqual("Folder", root.ResourceType);
            factory.Verify(a => a.CreateRootExplorerItem("Folder", It.IsAny<string>(), It.IsAny<Guid>()));
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_AssertFolderFails_ExpectErrorMessage()
        {
             //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var testCatalogue = new Mock<ITestCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                "Folder",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameItem(explorerItem, "bob", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: bob", result.Message);
            Assert.AreEqual(ExecStatus.NoMatch, result.Status);
        }




        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
             //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var testCatalogue = new Mock<ITestCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid)).Returns(res.Object);

            catalogue.Setup(a => a.RenameResource(It.IsAny<Guid>(), guid, "dave","bob")).Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.AccessViolation }).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("moo", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.AccessViolation);
            catalogue.Verify(a => a.RenameResource(It.IsAny<Guid>(), guid, "dave","bob"));
            catalogue.Verify(a => a.GetResourceList(It.IsAny<Guid>()));
        }
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_DuplicateExists_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(a => a.ResourceName).Returns("dave");
            res.Setup(resource => resource.ResourceID).Returns(guid);
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob\\dave");
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid)).Returns(res.Object);

            catalogue.Setup(a => a.RenameResource(It.IsAny<Guid>(), guid, "dave","bob")).Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.AccessViolation }).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("There is an item that exists with the same name and path", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }


        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_MoveItem")]
        public void ServerExplorerRepository_MoveItem_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("dave");
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "dave"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid)).Returns(res.Object);
            catalogue.Setup(a => a.RenameCategory(It.IsAny<Guid>(), "bob", "dave", It.IsAny<List<IResource>>()))
                .Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.AccessViolation })
                .Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var fileWrapper = new Mock<IFile>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, fileWrapper.Object, testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.MoveItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("There is an item that exists with the same name and path", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            catalogue.Verify(a => a.RenameCategory(It.IsAny<Guid>(), "bob", "dave", It.IsAny<List<IResource>>()), Times.Exactly(0));
            catalogue.Verify(a => a.GetResourceList(It.IsAny<Guid>()));
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_MoveItem")]
        public void ServerExplorerRepository_MoveItem_ResourceDoesNotexist_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------.
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(resource => resource.GetResourcePath(It.IsAny<Guid>())).Returns("");
            res.Setup(resource => resource.GetSavePath()).Returns("bob");
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid)).Returns(res.Object);
            catalogue.Setup(a => a.RenameCategory(It.IsAny<Guid>(), "bob", "dave", It.IsAny<List<IResource>>()))
                .Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.AccessViolation })
                .Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var fileWrapper = new Mock<IFile>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, fileWrapper.Object, testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.MoveItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("moo", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.AccessViolation);
            catalogue.Verify(a => a.RenameCategory(It.IsAny<Guid>(), "bob", "dave", It.IsAny<List<IResource>>()));
            catalogue.Verify(a => a.GetResourceList(It.IsAny<Guid>()));
        }


        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_MoveItem")]
        public void ServerExplorerRepository_MoveItem_ResourceDoesExistSubFolder_ExpectSuccess()
        {
            //------------Setup for test--------------------------.
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(resource => resource.GetResourcePath(It.IsAny<Guid>())).Returns("");
            res.Setup(resource => resource.GetSavePath()).Returns("bob\\dave");
            var explorerItem = new ServerExplorerItem(
                "mary", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob\\dave"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid)).Returns(res.Object);
            catalogue.Setup(a => a.RenameCategory(It.IsAny<Guid>(), "bob\\dave", "dave", It.IsAny<List<IResource>>()))
                .Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.Success })
                .Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var fileWrapper = new Mock<IFile>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, fileWrapper.Object, testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.MoveItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("moo", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Success);
            catalogue.Verify(a => a.RenameCategory(It.IsAny<Guid>(), "bob\\dave", "dave", It.IsAny<List<IResource>>()));
            catalogue.Verify(a => a.GetResourceList(It.IsAny<Guid>()));
        }


        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_DeleteItem_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();

            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), guid, "DbSource")).Returns(new ResourceCatalogResult { Message = "bob", Status = ExecStatus.DuplicateMatch });
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteItem(explorerItem, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("bob", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.DuplicateMatch);
            catalogue.Verify(a => a.DeleteResource(It.IsAny<Guid>(), guid, "DbSource"));
        }

        [Test]
        [Author("Nkosinathi Sangweni")]
        [Category("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_DeleteItem_DeleteTests_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();

            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), guid, "DbSource")).Returns(new ResourceCatalogResult { Message = "bob", Status = ExecStatus.DuplicateMatch });
            testCatalogue.Setup(catalog => catalog.DeleteAllTests(It.IsAny<Guid>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteItem(explorerItem, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("bob", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.DuplicateMatch);
            catalogue.Verify(a => a.DeleteResource(It.IsAny<Guid>(), guid, "DbSource"));
            testCatalogue.Verify(catalog => catalog.DeleteAllTests(It.IsAny<Guid>()), Times.Once);
        }
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_DeleteItemFolder_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();

            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "Folder",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteItem(explorerItem, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: bob", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_AssertResourcesAreRenames_FolderRenamedCatalogueSaved()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var resourceCatalogResult = new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" };
            catalogue.Setup(catalog => catalog.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>())).Returns(resourceCatalogResult);
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "monkey\\dave"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("monkey\\dave");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual("Error Renaming", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
        }


        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_AssertResourcesAreRenames_EmptyFolderRenamed()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var resourceCatalogResult = new ResourceCatalogResult { Status = ExecStatus.NoMatch, Message = "" };
            catalogue.Setup(catalog => catalog.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>())).Returns(resourceCatalogResult);
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("monkey2");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual("Error Renaming", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_AssertResourcesAreRenames_HasVersions_ExpectVersionCopied()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var resourceCatalogResult = new ResourceCatalogResult { Status = ExecStatus.NoMatch, Message = "" };
            catalogue.Setup(catalog => catalog.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>())).Returns(resourceCatalogResult);
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("monkey2");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: monkey", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.NoMatch);
        }



        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_ResourceRenameSuccess_OldFolderDeleted()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var resourceCatalogResult = new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" };
            catalogue.Setup(catalog => catalog.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>())).Returns(resourceCatalogResult);
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("monkey2");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: monkey", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.NoMatch);
        }

        [Test]
        [Author("Hagashen Naidu")]
        [Category("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_ResourceCatalogFailure_ErrorReturnedNoDelete()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var resourceCatalogResult = new ResourceCatalogResult { Status = ExecStatus.Fail, Message = "Error Renaming" };
            catalogue.Setup(catalog => catalog.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>())).Returns(resourceCatalogResult);
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                "DbSource",
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("monkey2");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual("Error Renaming", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameFolder_FolderDoesNotexist_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);


            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: monkey", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.NoMatch);

        }
        
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_FolderExists_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            sync.Setup(m => m.AddItemMessage(It.IsAny<IExplorerItem>())).Verifiable();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), "Folder", null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder already exists on server.", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            sync.Verify(m => m.AddItemMessage(It.IsAny<IExplorerItem>()), Times.Never());
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_InvalidItemType_ExpectErrorResult()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            var sync = new Mock<IExplorerRepositorySync>();
            sync.Setup(m => m.AddItemMessage(It.IsAny<IExplorerItem>())).Verifiable();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), "ReservedService", null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Only user resources can be added from this repository", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            sync.Verify(m => m.AddItemMessage(It.IsAny<IExplorerItem>()), Times.Never());
        }


        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_ValidFolder_ExpectCreatedFolder()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            factory.Setup(itemFactory => itemFactory.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(new ServerExplorerItem("root",Guid.Empty, "Server",new List<IExplorerItem>(),Permissions.Administrator,""));
            var sync = new Mock<IExplorerRepositorySync>();
            sync.Setup(m => m.AddItemMessage(It.IsAny<IExplorerItem>())).Verifiable();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            dir.Setup(a => a.CreateIfNotExists(It.IsAny<string>()));
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            serverExplorerRepository.Load(GlobalConstants.ServerWorkspaceID);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), "Folder", null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Success);
            dir.Verify(a => a.Exists(It.IsAny<string>()));
            dir.Verify(a => a.CreateIfNotExists(It.IsAny<string>()));
            sync.Verify(m => m.AddItemMessage(It.IsAny<IExplorerItem>()), Times.Once());
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_FileSystemException_ExpectErrorMessageFromException()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            dir.Setup(a => a.CreateIfNotExists(It.IsAny<string>())).Throws(new FileNotFoundException("bobe"));
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), "Folder", null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("bobe", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            dir.Verify(a => a.Exists(It.IsAny<string>()));
            dir.Verify(a => a.CreateIfNotExists(It.IsAny<string>()));

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItems_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            //------------Execute Test---------------------------
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", false, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: " + "bob", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NonExistent_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            //------------Execute Test---------------------------
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", false, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("Requested folder does not exist on server. Folder: " + "bob", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }
        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_Root_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            //------------Execute Test---------------------------
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("  ", false, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("You may not delete the root path", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursive_ExpectDeletion()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob\\mona");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns("EmailSource");
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", "EmailSource", true)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Verifiable();
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Success);
            dir.Verify(a => a.Delete(It.IsAny<string>(), true));

        }

        [Test]
        [Author("Nkosinathi Sangweni")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursiveWithTests_ExpectTestsDeletion()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            testCatalogue.Setup(catalog => catalog.DeleteAllTests(It.IsAny<Guid>())).Verifiable("Delete Not ran");
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns("EmailSource");
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", "EmailSource", true)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Verifiable();
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Success);
            dir.Verify(a => a.Delete(It.IsAny<string>(), true));
            testCatalogue.Verify(catalog => catalog.DeleteAllTests(guid), Times.Once);

        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursive_MultipleItemsToDelete_ExpectDeletion()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob\\mona");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns("EmailSource");

            var guid2 = Guid.NewGuid();
            var res2 = new Mock<IResource>();
            res2.Setup(a => a.ResourceName).Returns("mona1");
            res2.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob\\mona1");
            res2.Setup(a => a.ResourceID).Returns(guid2);
            res2.Setup(a => a.ResourceType).Returns("DbSource");

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var resources = new List<IResource> { res.Object, res2.Object };
            catalogue.SetupSequence(catalog => catalog.GetResourceList(It.IsAny<Guid>()))
                .Returns(resources)
                .Returns(resources);
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", "EmailSource", true)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Callback(() => resources.RemoveAt(0)).Verifiable();
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona1", "DbSource", true)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Verifiable();
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("", result.Message);
            Assert.AreEqual(ExecStatus.Success, result.Status);
            dir.Verify(a => a.Delete(It.IsAny<string>(), true));

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursiveFilesystemError_ExpectError()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            var guid = Guid.NewGuid();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob\\mona");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns("EmailSource");
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", "EmailSource", true)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Verifiable();
            dir.Setup(a => a.Delete(It.IsAny<string>(), true)).Throws(new FieldAccessException("moon"));
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("moon", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            dir.Verify(a => a.Delete(It.IsAny<string>(), true));

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursiveNestedFails_ExpectFailue()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            var guid = Guid.NewGuid();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.GetResourcePath(It.IsAny<Guid>())).Returns("bob\\mona");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns("EmailSource");
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", "EmailSource", true)).Returns(new ResourceCatalogResult { Status = ExecStatus.Fail, Message = "fanta" }).Verifiable();
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            dir.Verify(a => a.Delete(It.IsAny<string>(), true), Times.Once());
            Assert.AreEqual(ExecStatus.Success, result.Status);
            Assert.AreEqual("", result.Message);

        }

        [Test]
        [Author("Tshepo Ntlhokoa")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("ServerExplorerRepository_MessageSubscription")]
        public void ServerExplorerRepository_MessageSubscription_ParamIsNull_ThrowsException()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            //------------Execute Test---------------------------
            repo.MessageSubscription(null);
        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_AddItem")]
        public void ServerExplorerRepository_AddItem_VerifyNullThrowsException()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var res = repo.AddItem(null, Guid.NewGuid());
            Assert.AreEqual(ExecStatus.Fail, res.Status);
            Assert.AreEqual("Item to add was null", res.Message);
            

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_VerifyNullThrowsException()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var res = repo.RenameItem(null, "bob", Guid.NewGuid());
            Assert.AreEqual(ExecStatus.Fail, res.Status);
            Assert.AreEqual("Item to rename was null", res.Message);
            

        }

        [Test]
        [Author("Leon Rajindrapersadh")]
        [Category("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_AddItem_VerifyDeleteThrowsException()
        {
            //------------Setup for test--------------------------
            var testCatalogue = new Mock<ITestCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(new Config(catalogue.Object, factory.Object, dir.Object, new FileWrapper(), testCatalogue.Object), sync.Object);
            var res = repo.DeleteItem(null, Guid.NewGuid());
            Assert.AreEqual(ExecStatus.Fail, res.Status);
            Assert.AreEqual("Item to delete was null", res.Message);
            

        }
    }
}




