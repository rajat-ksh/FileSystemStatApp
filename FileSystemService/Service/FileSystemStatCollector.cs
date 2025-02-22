﻿using FileSystemStatsService.Interfaces;
using FileSystemStatsService.Models;
using FileSystemStatsService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemStatsService.Service
{
    public class FileSystemStatCollector : IFileSystemStatCollector
    {
        private readonly IFileSystemDataRepository _repository;

        public FileSystemStatCollector(IFileSystemDataRepository repository)
        {
            _repository = repository;
        }

        public int Start(string driveLetter)
        {
            var item = _repository.GetByName(driveLetter);
            if (item is Folder)
                return item.GetInnerItemsCount();
            return 0;
        }

        public IEnumerable<string> GetByLevel(int level = 0)
        {
            return _repository.GetByLevel(level);
        }

        public IEnumerable<string> GetUniqueNamesByLevel(int level = 0)
        {
            var items = _repository.GetByLevel(level);
            return items?.Distinct();
        }

        public IEnumerable<string> GetUniqueNamesBy(IEnumerable<string> nameFilter, bool isReadOnly)
        {
            throw new NotImplementedException();
        }
    }
}
