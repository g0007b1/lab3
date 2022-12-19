using LW1.Controllers.Memory.Enums;

namespace LW1.Extensions
{
    public static class StorageEnumExtensions
    {
        public static StorageEnum ToStorageEnum(this string value)
        {
            switch (value)
            {
                case var _ when value.ToLowerInvariant() == "memcache"
                                || value.ToLowerInvariant() == "cache"
                                || value.ToLowerInvariant() == "mem":
                    return StorageEnum.MemCache;
                case var _ when value.ToLowerInvariant() == "filestorage"
                                || value.ToLowerInvariant() == "file"
                                || value.ToLowerInvariant() == "storage":
                    return StorageEnum.FileStorage;
                default:
                    return StorageEnum.Undefined;
            }
        }
    }
}
