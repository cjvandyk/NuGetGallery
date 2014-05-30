﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using NuGetGallery.Packaging;

namespace NuGetGallery
{
    public class NuGetExeDownloaderService : INuGetExeDownloaderService
    {
        private const int MaxNuGetExeFileSize = 10 * 1024 * 1024;
        private readonly IFileStorageService _fileStorageService;
        private readonly IPackageFileService _packageFileService;
        private readonly IPackageService _packageService;

        public NuGetExeDownloaderService(
            IPackageService packageService,
            IPackageFileService packageFileService,
            IFileStorageService fileStorageService)
        {
            _packageService = packageService;
            _packageFileService = packageFileService;
            _fileStorageService = fileStorageService;
        }

        public Task<ActionResult> CreateNuGetExeDownloadActionResultAsync(Uri requestUrl)
        {
            return _fileStorageService.CreateDownloadFileActionResultAsync(requestUrl, Constants.DownloadsFolderName, "nuget.exe");
        }
    }
}
