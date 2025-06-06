// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START storage_list_soft_deleted_objects]

using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;

public class ListSoftDeletedObjectsSample
{
    /// <summary>
    /// List all soft-deleted objects in the bucket.
    /// </summary>
    /// <param name="bucketName">The name of the bucket.</param>
    public IEnumerable<Google.Apis.Storage.v1.Data.Object> ListSoftDeletedObjects(string bucketName = "your-unique-bucket-name")
    {
        var storage = StorageClient.Create();
        var objects = storage.ListObjects(bucketName, prefix: null, new ListObjectsOptions { SoftDeletedOnly = true });
        Console.WriteLine($"The Names of the Soft Deleted Objects in the Bucket (Bucket Name: {bucketName}) are as follows:");
        foreach (var obj in objects)
        {
            Console.WriteLine($"Object Name: {obj.Name}");
        }
        return objects;
    }
}
// [END storage_list_soft_deleted_objects]
