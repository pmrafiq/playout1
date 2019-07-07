﻿using System;
using TAS.Common.Interfaces.Media;

namespace TAS.Common.Interfaces.MediaDirectory
{
    public interface IArchiveDirectory: IMediaDirectory
    {
        IArchiveMedia Find(Guid mediaGuid);
    }

    public interface IArchiveDirectoryProperties: IMediaDirectoryProperties
    {
        ulong IdArchive { get; set; }
    }

    public interface IArchiveDirectoryServerSide : IMediaDirectoryServerSide, IArchiveDirectory, IArchiveDirectoryProperties
    {
    }
}
