/*
 * Copyright 2024 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.Cloud.SecretManager.V1;
using Xunit;

[Collection(nameof(RegionalSecretManagerFixture))]
public class GetRegionalSecretVersionTests
{
    private readonly RegionalSecretManagerFixture _fixture;
    private readonly GetRegionalSecretVersionSample _sample;

    public GetRegionalSecretVersionTests(RegionalSecretManagerFixture fixture)
    {
        _fixture = fixture;
        _sample = new GetRegionalSecretVersionSample();
    }

    [Fact]
    public void GetsRegionalSecretVersions()
    {
        // Get the secret version name.
        SecretVersionName secretVersionName = _fixture.SecretVersion.SecretVersionName;

        // Run the code sample.
        SecretVersion result = _sample.GetRegionalSecretVersion(
          projectId: secretVersionName.ProjectId,
          locationId: secretVersionName.LocationId,
          secretId: secretVersionName.SecretId,
          secretVersionId: secretVersionName.SecretVersionId
        );

        // Assert that the secretversion id is equal to expected value.
        Assert.Equal(result.SecretVersionName.SecretVersionId, secretVersionName.SecretVersionId);
    }
}
