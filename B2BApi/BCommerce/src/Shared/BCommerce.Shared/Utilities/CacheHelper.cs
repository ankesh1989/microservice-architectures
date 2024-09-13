using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BCommerce.Shared.Utilities
{
    public static class CacheHelper
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
                                                   string recordId,
                                                   T data,
                                                   TimeSpan? absoluteExpireTime = null,
                                                   TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            //options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            //options.SlidingExpiration = slidingExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache,
                                                       string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static async Task UpdateRecordAsync<T>(this IDistributedCache cache,
                                                  string recordId,
                                                  Func<T, T> updateAction,
                                                  TimeSpan? absoluteExpireTime = null,
                                                  TimeSpan? slidingExpireTime = null)
        {
            var existingData = await GetRecordAsync<T>(cache, recordId);

            if (existingData != null)
            {
                var updatedData = updateAction(existingData);

                await SetRecordAsync(cache, recordId, updatedData, absoluteExpireTime, slidingExpireTime);
            }
        }

        public static async Task AddNewRecordAsync<T>(this IDistributedCache cache,
                                                      string recordId,
                                                      T newData,
                                                      TimeSpan? absoluteExpireTime = null,
                                                      TimeSpan? slidingExpireTime = null)
        {
            var existingData = await GetRecordAsync<T>(cache, recordId);

            if (existingData == null)
            {
                await SetRecordAsync(cache, recordId, newData, absoluteExpireTime, slidingExpireTime);
            }
        }

        public static async Task AddObjectToArrayAsync<T>(this IDistributedCache cache,
                                            string recordId,
                                            T newData,
                                            TimeSpan? absoluteExpireTime = null,
                                            TimeSpan? slidingExpireTime = null)
        {
            var existingData = await GetRecordAsync<List<T>>(cache, recordId) ?? new List<T>();
            existingData.Add(newData);

            await SetRecordAsync(cache, recordId, existingData, absoluteExpireTime, slidingExpireTime);
        }

        public static async Task AddOrUpdateObjectInArrayAsync<T>(this IDistributedCache cache,
                                                             string recordId,
                                                             int objectId,
                                                             T newData,
                                                             TimeSpan? absoluteExpireTime = null,
                                                             TimeSpan? slidingExpireTime = null)
        {
            var existingData = await GetRecordAsync<List<T>>(cache, recordId) ?? new List<T>();

            var existingObject = existingData.FirstOrDefault(item =>
            {
                var propertyInfo = item.GetType().GetProperty("Id");
                var propertyValue = propertyInfo?.GetValue(item, null);
                return propertyValue != null && propertyValue.Equals(objectId);
            });

            if (existingObject != null)
            {
                existingData.Remove(existingObject);
                existingData.Add(newData);
            }
            else
            {
                existingData.Add(newData);
            }
            await SetRecordAsync(cache, recordId, existingData, absoluteExpireTime, slidingExpireTime);
        }

        public static async Task RemoveObjectInArrayAsync<T>(this IDistributedCache cache,
                                                       string recordId,
                                                       int objectId,
                                                       TimeSpan? absoluteExpireTime = null,
                                                       TimeSpan? slidingExpireTime = null)
        {
            var existingData = await GetRecordAsync<List<T>>(cache, recordId) ?? new List<T>();

            var existingObject = existingData.FirstOrDefault(item =>
            {
                var propertyInfo = item.GetType().GetProperty("Id");
                var propertyValue = propertyInfo?.GetValue(item, null);
                return propertyValue != null && propertyValue.Equals(objectId);
            });

            if (existingObject != null)
            {
                existingData.Remove(existingObject);
                await SetRecordAsync(cache, recordId, existingData, absoluteExpireTime, slidingExpireTime);
            }
        }
    }
}