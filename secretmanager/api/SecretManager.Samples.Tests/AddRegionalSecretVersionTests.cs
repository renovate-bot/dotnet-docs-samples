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
public class AddRegionalSecretVersionTests
{
    private readonly RegionalSecretManagerFixture _fixture;
    private readonly AddRegionalSecretVersionSample _sample;

    public AddRegionalSecretVersionTests(RegionalSecretManagerFixture fixture)
    {
        _fixture = fixture;
        _sample = new AddRegionalSecretVersionSample();
    }

    [Fact]
    public void AddsRegionalSecretVersions()
    {
        string data = "my secret data";

        // Create the secret and add secret version.
        Secret secret = _fixture.CreateSecret(_fixture.RandomId());
        SecretName secretName = secret.SecretName;
        SecretVersion secretVersion = _sample.AddRegionalSecretVersion(
          projectId: secretName.ProjectId,
          locationId: secretName.LocationId,
          secretId: secretName.SecretId,
          data: data
        );

        // Access the secret version.
        AccessSecretVersionResponse result = _fixture.Client.AccessSecretVersion(secretVersion.SecretVersionName);

        // Assert that the secret version was added with the correct data.
        Assert.Equal(data, result.Payload.Data.ToStringUtf8());

        // Clean the created secret.
        _fixture.DeleteSecret(secret.SecretName);
    }
}
