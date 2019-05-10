﻿using System;
using Newtonsoft.Json;
using TAS.Common;
using TAS.Common.Interfaces.Media;

namespace TAS.Remoting.Model.Media
{
    public class IngestMedia: MediaBase, IIngestMedia
    {
        #pragma warning disable CS0649

        [JsonProperty(nameof(IIngestMedia.IngestStatus))]
        private TIngestStatus _ingestStatus;

        private readonly Lazy<TIngestStatus> _ingestStatusLazy;
        #pragma warning restore

        public IngestMedia()
        {
            _ingestStatusLazy = new Lazy<TIngestStatus>(() =>
            {
                _ingestStatus = Get<TIngestStatus>(nameof(IngestStatus));
                return _ingestStatus;
            });
        }

        public TIngestStatus IngestStatus => _ingestStatusLazy.IsValueCreated ? _ingestStatus : _ingestStatusLazy.Value;
    }
}