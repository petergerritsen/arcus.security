﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GuardNet;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace Arcus.Security.Tests.Unit.KeyVault.Doubles
{
    /// <summary>
    ///     Representation of an <see cref="IKeyVaultClient"/> that simulates a series of key vault responses based on requests.
    /// </summary>
    public class SimulatedKeyVaultClient : IKeyVaultClient
    {
        private readonly Func<SecretBundle>[] _simulation;
        
        private int _simulationCount = -1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SimulatedKeyVaultClient"/> class.
        /// </summary>
        /// <param name="simulation">The simulation of key vault requests the simulated client should run through.</param>
        public SimulatedKeyVaultClient(params Func<SecretBundle>[] simulation)
        {
            Guard.NotNull(simulation, nameof(simulation));

            _simulation = simulation;
        }

        /// <summary>Gets the certificate operation response.</summary>
        /// <param name="vault">
        /// The vault name, e.g. https://myvault.vault.azure.net
        /// </param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<string>> GetPendingCertificateSigningRequestWithHttpMessagesAsync(
            string vault,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new key, stores it, then returns key parameters and
        /// attributes to the client.
        /// </summary>
        /// <remarks>
        /// The create key operation can be used to create any key type in
        /// Azure Key Vault. If the named key already exists, Azure Key Vault
        /// creates a new version of the key. It requires the keys/create
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">
        /// The name for the new key. The system will generate the version name
        /// for the new key.
        /// </param>
        /// <param name="kty">
        /// The type of key to create. For valid values, see Microsoft.Azure.KeyVault.WebKey.JsonWebKeyType.
        /// Possible values include: 'EC', 'EC-HSM', 'RSA', 'RSA-HSM', 'oct'
        /// </param>
        /// <param name="keySize">
        /// The key size in bits. For example: 2048, 3072, or 4096 for RSA.
        /// </param>
        /// <param name="keyOps">
        /// </param>
        /// <param name="keyAttributes">
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="curve">
        /// Elliptic curve name. For valid values, see Microsoft.Azure.KeyVault.WebKey.JsonWebKeyCurveName.
        /// Possible values include: 'P-256', 'P-384', 'P-521', 'P-256K'
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyBundle>> CreateKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string kty,
            int? keySize = null,
            IList<string> keyOps = null,
            KeyAttributes keyAttributes = null,
            IDictionary<string, string> tags = null,
            string curve = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Imports an externally created key, stores it, and returns key
        /// parameters and attributes to the client.
        /// </summary>
        /// <remarks>
        /// The import key operation may be used to import any key type into an
        /// Azure Key Vault. If the named key already exists, Azure Key Vault
        /// creates a new version of the key. This operation requires the
        /// keys/import permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">Name for the imported key.</param>
        /// <param name="key">The Json web key</param>
        /// <param name="hsm">
        /// Whether to import as a hardware key (HSM) or software key.
        /// </param>
        /// <param name="keyAttributes">The key management attributes.</param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyBundle>> ImportKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            JsonWebKey key,
            bool? hsm = null,
            KeyAttributes keyAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a key of any type from storage in Azure Key Vault.
        /// </summary>
        /// <remarks>
        /// The delete key operation cannot be used to remove individual
        /// versions of a key. This operation removes the cryptographic
        /// material associated with the key, which means the key is not usable
        /// for Sign/Verify, Wrap/Unwrap or Encrypt/Decrypt operations. This
        /// operation requires the keys/delete permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key to delete.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedKeyBundle>> DeleteKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update key operation changes specified attributes of a stored
        /// key and can be applied to any key type and key version stored in
        /// Azure Key Vault.
        /// </summary>
        /// <remarks>
        /// In order to perform this operation, the key must already exist in
        /// the Key Vault. Note: The cryptographic material of a key itself
        /// cannot be changed. This operation requires the keys/update
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of key to update.</param>
        /// <param name="keyVersion">The version of the key to update.</param>
        /// <param name="keyOps">
        /// Json web key operations. For more information on possible key
        /// operations, see Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.
        /// </param>
        /// <param name="keyAttributes">
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyBundle>> UpdateKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            IList<string> keyOps = null,
            KeyAttributes keyAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the public part of a stored key.</summary>
        /// <remarks>
        /// The get key operation is applicable to all key types. If the
        /// requested key is symmetric, then no key material is released in the
        /// response. This operation requires the keys/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key to get.</param>
        /// <param name="keyVersion">
        /// Adding the version parameter retrieves a specific version of a key.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyBundle>> GetKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a list of individual key versions with the same key name.
        /// </summary>
        /// <remarks>
        /// The full key identifier, attributes, and tags are provided in the
        /// response. This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<KeyItem>>> GetKeyVersionsWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List keys in the specified vault.</summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault as JSON Web Key
        /// structures that contain the public part of a stored key. The LIST
        /// operation is applicable to all key types, however only the base key
        /// identifier, attributes, and tags are provided in the response.
        /// Individual versions of a key are not listed in the response. This
        /// operation requires the keys/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<KeyItem>>> GetKeysWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the
        /// client.
        /// </summary>
        /// <remarks>
        /// The Key Backup operation exports a key from Azure Key Vault in a
        /// protected form. Note that this operation does NOT return key
        /// material in a form that can be used outside the Azure Key Vault
        /// system, the returned key material is either protected to a Azure
        /// Key Vault HSM or to Azure Key Vault itself. The intent of this
        /// operation is to allow a client to GENERATE a key in one Azure Key
        /// Vault instance, BACKUP the key, and then RESTORE it into another
        /// Azure Key Vault instance. The BACKUP operation may be used to
        /// export, in protected form, any key type from Azure Key Vault.
        /// Individual versions of a key cannot be backed up. BACKUP / RESTORE
        /// can be performed within geographical boundaries only; meaning that
        /// a BACKUP from one geographical area cannot be restored to another
        /// geographical area. For example, a backup from the US geographical
        /// area cannot be restored in an EU geographical area. This operation
        /// requires the key/backup permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<BackupKeyResult>> BackupKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Restores a backed up key to a vault.</summary>
        /// <remarks>
        /// Imports a previously backed up key into Azure Key Vault, restoring
        /// the key, its key identifier, attributes and access control
        /// policies. The RESTORE operation may be used to import a previously
        /// backed up key. Individual versions of a key cannot be restored. The
        /// key is restored in its entirety with the same key name as it had
        /// when it was backed up. If the key name is not available in the
        /// target Key Vault, the RESTORE operation will be rejected. While the
        /// key name is retained during restore, the final key identifier will
        /// change if the key is restored to a different vault. Restore will
        /// restore all versions and preserve version identifiers. The RESTORE
        /// operation is subject to security constraints: The target Key Vault
        /// must be owned by the same Microsoft Azure Subscription as the
        /// source Key Vault The user must have RESTORE permission in the
        /// target Key Vault. This operation requires the keys/restore
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyBundleBackup">
        /// The backup blob associated with a key bundle.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyBundle>> RestoreKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            byte[] keyBundleBackup,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encrypts an arbitrary sequence of bytes using an encryption key
        /// that is stored in a key vault.
        /// </summary>
        /// <remarks>
        /// The ENCRYPT operation encrypts an arbitrary sequence of bytes using
        /// an encryption key that is stored in Azure Key Vault. Note that the
        /// ENCRYPT operation only supports a single block of data, the size of
        /// which is dependent on the target key and the encryption algorithm
        /// to be used. The ENCRYPT operation is only strictly necessary for
        /// symmetric keys stored in Azure Key Vault since protection with an
        /// asymmetric key can be performed using public portion of the key.
        /// This operation is supported for asymmetric keys as a convenience
        /// for callers that have a key-reference but do not have access to the
        /// public key material. This operation requires the keys/encypt
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="algorithm">
        /// algorithm identifier. Possible values include: 'RSA-OAEP',
        /// 'RSA-OAEP-256', 'RSA1_5'
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyOperationResult>> EncryptWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            string algorithm,
            byte[] value,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Decrypts a single block of encrypted data.</summary>
        /// <remarks>
        /// The DECRYPT operation decrypts a well-formed block of ciphertext
        /// using the target encryption key and specified algorithm. This
        /// operation is the reverse of the ENCRYPT operation; only a single
        /// block of data may be decrypted, the size of this block is dependent
        /// on the target key and the algorithm to be used. The DECRYPT
        /// operation applies to asymmetric and symmetric keys stored in Azure
        /// Key Vault since it uses the private portion of the key. This
        /// operation requires the keys/decrypt permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="algorithm">
        /// algorithm identifier. Possible values include: 'RSA-OAEP',
        /// 'RSA-OAEP-256', 'RSA1_5'
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyOperationResult>> DecryptWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            string algorithm,
            byte[] value,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a signature from a digest using the specified key.
        /// </summary>
        /// <remarks>
        /// The SIGN operation is applicable to asymmetric and symmetric keys
        /// stored in Azure Key Vault since this operation uses the private
        /// portion of the key. This operation requires the keys/sign
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="algorithm">
        /// The signing/verification algorithm identifier. For more information
        /// on possible algorithm types, see Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.
        /// Possible values include: 'PS256', 'PS384', 'PS512', 'RS256',
        /// 'RS384', 'RS512', 'RSNULL', 'ES256', 'ES384', 'ES512', 'ES256K'
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyOperationResult>> SignWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            string algorithm,
            byte[] value,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Verifies a signature using a specified key.</summary>
        /// <remarks>
        /// The VERIFY operation is applicable to symmetric keys stored in
        /// Azure Key Vault. VERIFY is not strictly necessary for asymmetric
        /// keys stored in Azure Key Vault since signature verification can be
        /// performed using the public portion of the key but this operation is
        /// supported as a convenience for callers that only have a
        /// key-reference and not the public portion of the key. This operation
        /// requires the keys/verify permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="algorithm">
        /// The signing/verification algorithm. For more information on
        /// possible algorithm types, see Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.
        /// Possible values include: 'PS256', 'PS384', 'PS512', 'RS256',
        /// 'RS384', 'RS512', 'RSNULL', 'ES256', 'ES384', 'ES512', 'ES256K'
        /// </param>
        /// <param name="digest">The digest used for signing.</param>
        /// <param name="signature">The signature to be verified.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyVerifyResult>> VerifyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            string algorithm,
            byte[] digest,
            byte[] signature,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Wraps a symmetric key using a specified key.</summary>
        /// <remarks>
        /// The WRAP operation supports encryption of a symmetric key using a
        /// key encryption key that has previously been stored in an Azure Key
        /// Vault. The WRAP operation is only strictly necessary for symmetric
        /// keys stored in Azure Key Vault since protection with an asymmetric
        /// key can be performed using the public portion of the key. This
        /// operation is supported for asymmetric keys as a convenience for
        /// callers that have a key-reference but do not have access to the
        /// public key material. This operation requires the keys/wrapKey
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="algorithm">
        /// algorithm identifier. Possible values include: 'RSA-OAEP',
        /// 'RSA-OAEP-256', 'RSA1_5'
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyOperationResult>> WrapKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            string algorithm,
            byte[] value,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unwraps a symmetric key using the specified key that was initially
        /// used for wrapping that key.
        /// </summary>
        /// <remarks>
        /// The UNWRAP operation supports decryption of a symmetric key using
        /// the target key encryption key. This operation is the reverse of the
        /// WRAP operation. The UNWRAP operation applies to asymmetric and
        /// symmetric keys stored in Azure Key Vault since it uses the private
        /// portion of the key. This operation requires the keys/unwrapKey
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="algorithm">
        /// algorithm identifier. Possible values include: 'RSA-OAEP',
        /// 'RSA-OAEP-256', 'RSA1_5'
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyOperationResult>> UnwrapKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            string keyVersion,
            string algorithm,
            byte[] value,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Lists the deleted keys in the specified vault.</summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault as JSON Web Key
        /// structures that contain the public part of a deleted key. This
        /// operation includes deletion-specific information. The Get Deleted
        /// Keys operation is applicable for vaults enabled for soft-delete.
        /// While the operation can be invoked on any vault, it will return an
        /// error if invoked on a non soft-delete enabled vault. This operation
        /// requires the keys/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedKeyItem>>> GetDeletedKeysWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the public part of a deleted key.</summary>
        /// <remarks>
        /// The Get Deleted Key operation is applicable for soft-delete enabled
        /// vaults. While the operation can be invoked on any vault, it will
        /// return an error if invoked on a non soft-delete enabled vault. This
        /// operation requires the keys/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedKeyBundle>> GetDeletedKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Permanently deletes the specified key.</summary>
        /// <remarks>
        /// The Purge Deleted Key operation is applicable for soft-delete
        /// enabled vaults. While the operation can be invoked on any vault, it
        /// will return an error if invoked on a non soft-delete enabled vault.
        /// This operation requires the keys/purge permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the key</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse> PurgeDeletedKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Recovers the deleted key to its latest version.</summary>
        /// <remarks>
        /// The Recover Deleted Key operation is applicable for deleted keys in
        /// soft-delete enabled vaults. It recovers the deleted key back to its
        /// latest version under /keys. An attempt to recover an non-deleted
        /// key will return an error. Consider this the inverse of the delete
        /// operation on soft-delete enabled vaults. This operation requires
        /// the keys/recover permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="keyName">The name of the deleted key.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<KeyBundle>> RecoverDeletedKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string keyName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Sets a secret in a specified key vault.</summary>
        /// <remarks>
        /// The SET operation adds a secret to the Azure Key Vault. If the
        /// named secret already exists, Azure Key Vault creates a new version
        /// of that secret. This operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="value">The value of the secret.</param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="contentType">
        /// Type of the secret value such as a password.
        /// </param>
        /// <param name="secretAttributes">The secret management attributes.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SecretBundle>> SetSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            string value,
            IDictionary<string, string> tags = null,
            string contentType = null,
            SecretAttributes secretAttributes = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Deletes a secret from a specified key vault.</summary>
        /// <remarks>
        /// The DELETE operation applies to any secret stored in Azure Key
        /// Vault. DELETE cannot be applied to an individual version of a
        /// secret. This operation requires the secrets/delete permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedSecretBundle>> DeleteSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the attributes associated with a specified secret in a
        /// given key vault.
        /// </summary>
        /// <remarks>
        /// The UPDATE operation changes specified attributes of an existing
        /// stored secret. Attributes that are not specified in the request are
        /// left unchanged. The value of a secret itself cannot be changed.
        /// This operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="secretVersion">The version of the secret.</param>
        /// <param name="contentType">
        /// Type of the secret value such as a password.
        /// </param>
        /// <param name="secretAttributes">The secret management attributes.</param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SecretBundle>> UpdateSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            string secretVersion,
            string contentType = null,
            SecretAttributes secretAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Get a specified secret from a given key vault.</summary>
        /// <remarks>
        /// The GET operation is applicable to any secret stored in Azure Key
        /// Vault. This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="secretVersion">The version of the secret.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SecretBundle>> GetSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            string secretVersion,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Interlocked.Increment(ref _simulationCount);
            var response = new AzureOperationResponse<SecretBundle>
            {
                Body = _simulation[_simulationCount]()
            };
            
            return Task.FromResult(response);
        }

        /// <summary>List secrets in a specified key vault.</summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault.
        /// However, only the base secret identifier and its attributes are
        /// provided in the response. Individual secret versions are not listed
        /// in the response. This operation requires the secrets/list
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified,
        /// the service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<SecretItem>>> GetSecretsWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List all versions of the specified secret.</summary>
        /// <remarks>
        /// The full secret identifier and attributes are provided in the
        /// response. No values are returned for the secrets. This operations
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified,
        /// the service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<SecretItem>>> GetSecretVersionsWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Lists deleted secrets for the specified vault.</summary>
        /// <remarks>
        /// The Get Deleted Secrets operation returns the secrets that have
        /// been deleted for a vault enabled for soft-delete. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedSecretItem>>> GetDeletedSecretsWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the specified deleted secret.</summary>
        /// <remarks>
        /// The Get Deleted Secret operation returns the specified deleted
        /// secret along with its attributes. This operation requires the
        /// secrets/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedSecretBundle>> GetDeletedSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Permanently deletes the specified secret.</summary>
        /// <remarks>
        /// The purge deleted secret operation removes the secret permanently,
        /// without the possibility of recovery. This operation can only be
        /// enabled on a soft-delete enabled vault. This operation requires the
        /// secrets/purge permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse> PurgeDeletedSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Recovers the deleted secret to the latest version.</summary>
        /// <remarks>
        /// Recovers the deleted secret in the specified vault. This operation
        /// can only be performed on a soft-delete enabled vault. This
        /// operation requires the secrets/recover permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the deleted secret.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SecretBundle>> RecoverDeletedSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Backs up the specified secret.</summary>
        /// <remarks>
        /// Requests that a backup of the specified secret be downloaded to the
        /// client. All versions of the secret will be downloaded. This
        /// operation requires the secrets/backup permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretName">The name of the secret.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<BackupSecretResult>> BackupSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            string secretName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Restores a backed up secret to a vault.</summary>
        /// <remarks>
        /// Restores a backed up secret, and all its versions, to a vault. This
        /// operation requires the secrets/restore permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="secretBundleBackup">
        /// The backup blob associated with a secret bundle.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SecretBundle>> RestoreSecretWithHttpMessagesAsync(
            string vaultBaseUrl,
            byte[] secretBundleBackup,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List certificates in a specified key vault</summary>
        /// <remarks>
        /// The GetCertificates operation returns the set of certificates
        /// resources in the specified key vault. This operation requires the
        /// certificates/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="includePending">
        /// Specifies whether to include certificates which are not completely
        /// provisioned.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<CertificateItem>>> GetCertificatesWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            bool? includePending = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Deletes a certificate from a specified key vault.</summary>
        /// <remarks>
        /// Deletes all versions of a certificate object along with its
        /// associated policy. Delete certificate cannot be used to remove
        /// individual versions of a certificate object. This operation
        /// requires the certificates/delete permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedCertificateBundle>> DeleteCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the certificate contacts for the specified key vault.
        /// </summary>
        /// <remarks>
        /// Sets the certificate contacts for the specified key vault. This
        /// operation requires the certificates/managecontacts permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="contacts">
        /// The contacts for the key vault certificate.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<Contacts>> SetCertificateContactsWithHttpMessagesAsync(
            string vaultBaseUrl,
            Contacts contacts,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists the certificate contacts for a specified key vault.
        /// </summary>
        /// <remarks>
        /// The GetCertificateContacts operation returns the set of certificate
        /// contact resources in the specified key vault. This operation
        /// requires the certificates/managecontacts permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<Contacts>> GetCertificateContactsWithHttpMessagesAsync(
            string vaultBaseUrl,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the certificate contacts for a specified key vault.
        /// </summary>
        /// <remarks>
        /// Deletes the certificate contacts for a specified key vault
        /// certificate. This operation requires the
        /// certificates/managecontacts permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<Contacts>> DeleteCertificateContactsWithHttpMessagesAsync(
            string vaultBaseUrl,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List certificate issuers for a specified key vault.</summary>
        /// <remarks>
        /// The GetCertificateIssuers operation returns the set of certificate
        /// issuer resources in the specified key vault. This operation
        /// requires the certificates/manageissuers/getissuers permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<CertificateIssuerItem>>> GetCertificateIssuersWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Sets the specified certificate issuer.</summary>
        /// <remarks>
        /// The SetCertificateIssuer operation adds or updates the specified
        /// certificate issuer. This operation requires the
        /// certificates/setissuers permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="issuerName">The name of the issuer.</param>
        /// <param name="provider">The issuer provider.</param>
        /// <param name="credentials">
        /// The credentials to be used for the issuer.
        /// </param>
        /// <param name="organizationDetails">
        /// Details of the organization as provided to the issuer.
        /// </param>
        /// <param name="attributes">Attributes of the issuer object.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IssuerBundle>> SetCertificateIssuerWithHttpMessagesAsync(
            string vaultBaseUrl,
            string issuerName,
            string provider,
            IssuerCredentials credentials = null,
            OrganizationDetails organizationDetails = null,
            IssuerAttributes attributes = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Updates the specified certificate issuer.</summary>
        /// <remarks>
        /// The UpdateCertificateIssuer operation performs an update on the
        /// specified certificate issuer entity. This operation requires the
        /// certificates/setissuers permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="issuerName">The name of the issuer.</param>
        /// <param name="provider">The issuer provider.</param>
        /// <param name="credentials">
        /// The credentials to be used for the issuer.
        /// </param>
        /// <param name="organizationDetails">
        /// Details of the organization as provided to the issuer.
        /// </param>
        /// <param name="attributes">Attributes of the issuer object.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IssuerBundle>> UpdateCertificateIssuerWithHttpMessagesAsync(
            string vaultBaseUrl,
            string issuerName,
            string provider = null,
            IssuerCredentials credentials = null,
            OrganizationDetails organizationDetails = null,
            IssuerAttributes attributes = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Lists the specified certificate issuer.</summary>
        /// <remarks>
        /// The GetCertificateIssuer operation returns the specified
        /// certificate issuer resources in the specified key vault. This
        /// operation requires the certificates/manageissuers/getissuers
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="issuerName">The name of the issuer.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IssuerBundle>> GetCertificateIssuerWithHttpMessagesAsync(
            string vaultBaseUrl,
            string issuerName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Deletes the specified certificate issuer.</summary>
        /// <remarks>
        /// The DeleteCertificateIssuer operation permanently removes the
        /// specified certificate issuer from the vault. This operation
        /// requires the certificates/manageissuers/deleteissuers permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="issuerName">The name of the issuer.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IssuerBundle>> DeleteCertificateIssuerWithHttpMessagesAsync(
            string vaultBaseUrl,
            string issuerName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Creates a new certificate.</summary>
        /// <remarks>
        /// If this is the first version, the certificate resource is created.
        /// This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="certificatePolicy">
        /// The management policy for the certificate.
        /// </param>
        /// <param name="certificateAttributes">
        /// The attributes of the certificate (optional).
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateOperation>> CreateCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            CertificatePolicy certificatePolicy = null,
            CertificateAttributes certificateAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Imports a certificate into a specified key vault.</summary>
        /// <remarks>
        /// Imports an existing valid certificate, containing a private key,
        /// into Azure Key Vault. The certificate to be imported can be in
        /// either PFX or PEM format. If the certificate is in PEM format the
        /// PEM file must contain the key as well as x509 certificates. This
        /// operation requires the certificates/import permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="base64EncodedCertificate">
        /// Base64 encoded representation of the certificate object to import.
        /// This certificate needs to contain the private key.
        /// </param>
        /// <param name="password">
        /// If the private key in base64EncodedCertificate is encrypted, the
        /// password used for encryption.
        /// </param>
        /// <param name="certificatePolicy">
        /// The management policy for the certificate.
        /// </param>
        /// <param name="certificateAttributes">
        /// The attributes of the certificate (optional).
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateBundle>> ImportCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            string base64EncodedCertificate,
            string password = null,
            CertificatePolicy certificatePolicy = null,
            CertificateAttributes certificateAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List the versions of a certificate.</summary>
        /// <remarks>
        /// The GetCertificateVersions operation returns the versions of a
        /// certificate in the specified key vault. This operation requires the
        /// certificates/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<CertificateItem>>> GetCertificateVersionsWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Lists the policy for a certificate.</summary>
        /// <remarks>
        /// The GetCertificatePolicy operation returns the specified
        /// certificate policy resources in the specified key vault. This
        /// operation requires the certificates/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">
        /// The name of the certificate in a given key vault.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificatePolicy>> GetCertificatePolicyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Updates the policy for a certificate.</summary>
        /// <remarks>
        /// Set specified members in the certificate policy. Leave others as
        /// null. This operation requires the certificates/update permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">
        /// The name of the certificate in the given vault.
        /// </param>
        /// <param name="certificatePolicy">The policy for the certificate.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificatePolicy>> UpdateCertificatePolicyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            CertificatePolicy certificatePolicy,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified attributes associated with the given
        /// certificate.
        /// </summary>
        /// <remarks>
        /// The UpdateCertificate operation applies the specified update on the
        /// given certificate; the only elements updated are the certificate's
        /// attributes. This operation requires the certificates/update
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">
        /// The name of the certificate in the given key vault.
        /// </param>
        /// <param name="certificateVersion">The version of the certificate.</param>
        /// <param name="certificatePolicy">
        /// The management policy for the certificate.
        /// </param>
        /// <param name="certificateAttributes">
        /// The attributes of the certificate (optional).
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateBundle>> UpdateCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            string certificateVersion,
            CertificatePolicy certificatePolicy = null,
            CertificateAttributes certificateAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets information about a certificate.</summary>
        /// <remarks>
        /// Gets information about a specific certificate. This operation
        /// requires the certificates/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">
        /// The name of the certificate in the given vault.
        /// </param>
        /// <param name="certificateVersion">The version of the certificate.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateBundle>> GetCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            string certificateVersion,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Updates a certificate operation.</summary>
        /// <remarks>
        /// Updates a certificate creation operation that is already in
        /// progress. This operation requires the certificates/update
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="cancellationRequested">
        /// Indicates if cancellation was requested on the certificate
        /// operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateOperation>> UpdateCertificateOperationWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            bool cancellationRequested,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the creation operation of a certificate.</summary>
        /// <remarks>
        /// Gets the creation operation associated with a specified
        /// certificate. This operation requires the certificates/get
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateOperation>> GetCertificateOperationWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the creation operation for a specific certificate.
        /// </summary>
        /// <remarks>
        /// Deletes the creation operation for a specified certificate that is
        /// in the process of being created. The certificate is no longer
        /// created. This operation requires the certificates/update
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateOperation>> DeleteCertificateOperationWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Merges a certificate or a certificate chain with a key pair
        /// existing on the server.
        /// </summary>
        /// <remarks>
        /// The MergeCertificate operation performs the merging of a
        /// certificate or certificate chain with a key pair currently
        /// available in the service. This operation requires the
        /// certificates/create permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="x509Certificates">
        /// The certificate or the certificate chain to merge.
        /// </param>
        /// <param name="certificateAttributes">
        /// The attributes of the certificate (optional).
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateBundle>> MergeCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            IList<byte[]> x509Certificates,
            CertificateAttributes certificateAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Backs up the specified certificate.</summary>
        /// <remarks>
        /// Requests that a backup of the specified certificate be downloaded
        /// to the client. All versions of the certificate will be downloaded.
        /// This operation requires the certificates/backup permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<BackupCertificateResult>> BackupCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Restores a backed up certificate to a vault.</summary>
        /// <remarks>
        /// Restores a backed up certificate, and all its versions, to a vault.
        /// This operation requires the certificates/restore permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateBundleBackup">
        /// The backup blob associated with a certificate bundle.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateBundle>> RestoreCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            byte[] certificateBundleBackup,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists the deleted certificates in the specified vault currently
        /// available for recovery.
        /// </summary>
        /// <remarks>
        /// The GetDeletedCertificates operation retrieves the certificates in
        /// the current vault which are in a deleted state and ready for
        /// recovery or purging. This operation includes deletion-specific
        /// information. This operation requires the certificates/get/list
        /// permission. This operation can only be enabled on soft-delete
        /// enabled vaults.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="includePending">
        /// Specifies whether to include certificates which are not completely
        /// provisioned.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedCertificateItem>>> GetDeletedCertificatesWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            bool? includePending = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves information about the specified deleted certificate.
        /// </summary>
        /// <remarks>
        /// The GetDeletedCertificate operation retrieves the deleted
        /// certificate information plus its attributes, such as retention
        /// interval, scheduled permanent deletion and the current deletion
        /// recovery level. This operation requires the certificates/get
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedCertificateBundle>> GetDeletedCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permanently deletes the specified deleted certificate.
        /// </summary>
        /// <remarks>
        /// The PurgeDeletedCertificate operation performs an irreversible
        /// deletion of the specified certificate, without possibility for
        /// recovery. The operation is not available if the recovery level does
        /// not specify 'Purgeable'. This operation requires the
        /// certificate/purge permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse> PurgeDeletedCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recovers the deleted certificate back to its current version under
        /// /certificates.
        /// </summary>
        /// <remarks>
        /// The RecoverDeletedCertificate operation performs the reversal of
        /// the Delete operation. The operation is applicable in vaults enabled
        /// for soft-delete, and must be issued during the retention interval
        /// (available in the deleted certificate's attributes). This operation
        /// requires the certificates/recover permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="certificateName">
        /// The name of the deleted certificate
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<CertificateBundle>> RecoverDeletedCertificateWithHttpMessagesAsync(
            string vaultBaseUrl,
            string certificateName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List storage accounts managed by the specified key vault. This
        /// operation requires the storage/list permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<StorageAccountItem>>> GetStorageAccountsWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists deleted storage accounts for the specified vault.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Storage Accounts operation returns the storage
        /// accounts that have been deleted for a vault enabled for
        /// soft-delete. This operation requires the storage/list permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedStorageAccountItem>>> GetDeletedStorageAccountsWithHttpMessagesAsync(
            string vaultBaseUrl,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the specified deleted storage account.</summary>
        /// <remarks>
        /// The Get Deleted Storage Account operation returns the specified
        /// deleted storage account along with its attributes. This operation
        /// requires the storage/get permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedStorageBundle>> GetDeletedStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Permanently deletes the specified storage account.</summary>
        /// <remarks>
        /// The purge deleted storage account operation removes the secret
        /// permanently, without the possibility of recovery. This operation
        /// can only be performed on a soft-delete enabled vault. This
        /// operation requires the storage/purge permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse> PurgeDeletedStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Recovers the deleted storage account.</summary>
        /// <remarks>
        /// Recovers the deleted storage account in the specified vault. This
        /// operation can only be performed on a soft-delete enabled vault.
        /// This operation requires the storage/recover permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<StorageBundle>> RecoverDeletedStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Backs up the specified storage account.</summary>
        /// <remarks>
        /// Requests that a backup of the specified storage account be
        /// downloaded to the client. This operation requires the
        /// storage/backup permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<BackupStorageResult>> BackupStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Restores a backed up storage account to a vault.</summary>
        /// <remarks>
        /// Restores a backed up storage account to a vault. This operation
        /// requires the storage/restore permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageBundleBackup">
        /// The backup blob associated with a storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<StorageBundle>> RestoreStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            byte[] storageBundleBackup,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a storage account. This operation requires the
        /// storage/delete permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedStorageBundle>> DeleteStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets information about a specified storage account. This operation
        /// requires the storage/get permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<StorageBundle>> GetStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates or updates a new storage account. This operation requires
        /// the storage/set permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="resourceId">Storage account resource id.</param>
        /// <param name="activeKeyName">
        /// Current active storage account key name.
        /// </param>
        /// <param name="autoRegenerateKey">
        /// whether keyvault should manage the storage account for the user.
        /// </param>
        /// <param name="regenerationPeriod">
        /// The key regeneration time duration specified in ISO-8601 format.
        /// </param>
        /// <param name="storageAccountAttributes">
        /// The attributes of the storage account.
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<StorageBundle>> SetStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string resourceId,
            string activeKeyName,
            bool autoRegenerateKey,
            string regenerationPeriod = null,
            StorageAccountAttributes storageAccountAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified attributes associated with the given storage
        /// account. This operation requires the storage/set/update permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="activeKeyName">
        /// The current active storage account key name.
        /// </param>
        /// <param name="autoRegenerateKey">
        /// whether keyvault should manage the storage account for the user.
        /// </param>
        /// <param name="regenerationPeriod">
        /// The key regeneration time duration specified in ISO-8601 format.
        /// </param>
        /// <param name="storageAccountAttributes">
        /// The attributes of the storage account.
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<StorageBundle>> UpdateStorageAccountWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string activeKeyName = null,
            bool? autoRegenerateKey = null,
            string regenerationPeriod = null,
            StorageAccountAttributes storageAccountAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Regenerates the specified key value for the given storage account.
        /// This operation requires the storage/regeneratekey permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="keyName">The storage account key name.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<StorageBundle>> RegenerateStorageAccountKeyWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string keyName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List storage SAS definitions for the given storage account. This
        /// operation requires the storage/listsas permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<SasDefinitionItem>>> GetSasDefinitionsWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists deleted SAS definitions for the specified vault and storage
        /// account.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Sas Definitions operation returns the SAS
        /// definitions that have been deleted for a vault enabled for
        /// soft-delete. This operation requires the storage/listsas
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="maxresults">
        /// Maximum number of results to return in a page. If not specified the
        /// service will return up to 25 results.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedSasDefinitionItem>>> GetDeletedSasDefinitionsWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            int? maxresults = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the specified deleted sas definition.</summary>
        /// <remarks>
        /// The Get Deleted SAS Definition operation returns the specified
        /// deleted SAS definition along with its attributes. This operation
        /// requires the storage/getsas permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="sasDefinitionName">The name of the SAS definition.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedSasDefinitionBundle>> GetDeletedSasDefinitionWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string sasDefinitionName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Recovers the deleted SAS definition.</summary>
        /// <remarks>
        /// Recovers the deleted SAS definition for the specified storage
        /// account. This operation can only be performed on a soft-delete
        /// enabled vault. This operation requires the storage/recover
        /// permission.
        /// </remarks>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="sasDefinitionName">The name of the SAS definition.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SasDefinitionBundle>> RecoverDeletedSasDefinitionWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string sasDefinitionName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a SAS definition from a specified storage account. This
        /// operation requires the storage/deletesas permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="sasDefinitionName">The name of the SAS definition.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<DeletedSasDefinitionBundle>> DeleteSasDefinitionWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string sasDefinitionName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets information about a SAS definition for the specified storage
        /// account. This operation requires the storage/getsas permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="sasDefinitionName">The name of the SAS definition.</param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SasDefinitionBundle>> GetSasDefinitionWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string sasDefinitionName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates or updates a new SAS definition for the specified storage
        /// account. This operation requires the storage/setsas permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="sasDefinitionName">The name of the SAS definition.</param>
        /// <param name="templateUri">
        /// The SAS definition token template signed with an arbitrary key.
        /// Tokens created according to the SAS definition will have the same
        /// properties as the template.
        /// </param>
        /// <param name="sasType">
        /// The type of SAS token the SAS definition will create. Possible
        /// values include: 'account', 'service'
        /// </param>
        /// <param name="validityPeriod">
        /// The validity period of SAS tokens created according to the SAS
        /// definition.
        /// </param>
        /// <param name="sasDefinitionAttributes">
        /// The attributes of the SAS definition.
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SasDefinitionBundle>> SetSasDefinitionWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string sasDefinitionName,
            string templateUri,
            string sasType,
            string validityPeriod,
            SasDefinitionAttributes sasDefinitionAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified attributes associated with the given SAS
        /// definition. This operation requires the storage/setsas permission.
        /// </summary>
        /// <param name="vaultBaseUrl">
        /// The vault name, for example https://myvault.vault.azure.net.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="sasDefinitionName">The name of the SAS definition.</param>
        /// <param name="templateUri">
        /// The SAS definition token template signed with an arbitrary key.
        /// Tokens created according to the SAS definition will have the same
        /// properties as the template.
        /// </param>
        /// <param name="sasType">
        /// The type of SAS token the SAS definition will create. Possible
        /// values include: 'account', 'service'
        /// </param>
        /// <param name="validityPeriod">
        /// The validity period of SAS tokens created according to the SAS
        /// definition.
        /// </param>
        /// <param name="sasDefinitionAttributes">
        /// The attributes of the SAS definition.
        /// </param>
        /// <param name="tags">
        /// Application specific metadata in the form of key-value pairs.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<SasDefinitionBundle>> UpdateSasDefinitionWithHttpMessagesAsync(
            string vaultBaseUrl,
            string storageAccountName,
            string sasDefinitionName,
            string templateUri = null,
            string sasType = null,
            string validityPeriod = null,
            SasDefinitionAttributes sasDefinitionAttributes = null,
            IDictionary<string, string> tags = null,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a list of individual key versions with the same key name.
        /// </summary>
        /// <remarks>
        /// The full key identifier, attributes, and tags are provided in the
        /// response. This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<KeyItem>>> GetKeyVersionsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List keys in the specified vault.</summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault as JSON Web Key
        /// structures that contain the public part of a stored key. The LIST
        /// operation is applicable to all key types, however only the base key
        /// identifier, attributes, and tags are provided in the response.
        /// Individual versions of a key are not listed in the response. This
        /// operation requires the keys/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<KeyItem>>> GetKeysNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Lists the deleted keys in the specified vault.</summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault as JSON Web Key
        /// structures that contain the public part of a deleted key. This
        /// operation includes deletion-specific information. The Get Deleted
        /// Keys operation is applicable for vaults enabled for soft-delete.
        /// While the operation can be invoked on any vault, it will return an
        /// error if invoked on a non soft-delete enabled vault. This operation
        /// requires the keys/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedKeyItem>>> GetDeletedKeysNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List secrets in a specified key vault.</summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault.
        /// However, only the base secret identifier and its attributes are
        /// provided in the response. Individual secret versions are not listed
        /// in the response. This operation requires the secrets/list
        /// permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<SecretItem>>> GetSecretsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List all versions of the specified secret.</summary>
        /// <remarks>
        /// The full secret identifier and attributes are provided in the
        /// response. No values are returned for the secrets. This operations
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<SecretItem>>> GetSecretVersionsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>Lists deleted secrets for the specified vault.</summary>
        /// <remarks>
        /// The Get Deleted Secrets operation returns the secrets that have
        /// been deleted for a vault enabled for soft-delete. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedSecretItem>>> GetDeletedSecretsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List certificates in a specified key vault</summary>
        /// <remarks>
        /// The GetCertificates operation returns the set of certificates
        /// resources in the specified key vault. This operation requires the
        /// certificates/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<CertificateItem>>> GetCertificatesNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List certificate issuers for a specified key vault.</summary>
        /// <remarks>
        /// The GetCertificateIssuers operation returns the set of certificate
        /// issuer resources in the specified key vault. This operation
        /// requires the certificates/manageissuers/getissuers permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<CertificateIssuerItem>>> GetCertificateIssuersNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>List the versions of a certificate.</summary>
        /// <remarks>
        /// The GetCertificateVersions operation returns the versions of a
        /// certificate in the specified key vault. This operation requires the
        /// certificates/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<CertificateItem>>> GetCertificateVersionsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists the deleted certificates in the specified vault currently
        /// available for recovery.
        /// </summary>
        /// <remarks>
        /// The GetDeletedCertificates operation retrieves the certificates in
        /// the current vault which are in a deleted state and ready for
        /// recovery or purging. This operation includes deletion-specific
        /// information. This operation requires the certificates/get/list
        /// permission. This operation can only be enabled on soft-delete
        /// enabled vaults.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedCertificateItem>>> GetDeletedCertificatesNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List storage accounts managed by the specified key vault. This
        /// operation requires the storage/list permission.
        /// </summary>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<StorageAccountItem>>> GetStorageAccountsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists deleted storage accounts for the specified vault.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Storage Accounts operation returns the storage
        /// accounts that have been deleted for a vault enabled for
        /// soft-delete. This operation requires the storage/list permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedStorageAccountItem>>> GetDeletedStorageAccountsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List storage SAS definitions for the given storage account. This
        /// operation requires the storage/listsas permission.
        /// </summary>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<SasDefinitionItem>>> GetSasDefinitionsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists deleted SAS definitions for the specified vault and storage
        /// account.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Sas Definitions operation returns the SAS
        /// definitions that have been deleted for a vault enabled for
        /// soft-delete. This operation requires the storage/listsas
        /// permission.
        /// </remarks>
        /// <param name="nextPageLink">
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name="customHeaders">
        /// The headers that will be added to request.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<AzureOperationResponse<IPage<DeletedSasDefinitionItem>>> GetDeletedSasDefinitionsNextWithHttpMessagesAsync(
            string nextPageLink,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        /// <summary>The base URI of the service.</summary>
        /// <summary>Gets or sets json serialization settings.</summary>
        public JsonSerializerSettings SerializationSettings => throw new NotImplementedException();

        /// <summary>Gets or sets json deserialization settings.</summary>
        public JsonSerializerSettings DeserializationSettings => throw new NotImplementedException();

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        public ServiceClientCredentials Credentials => throw new NotImplementedException();

        /// <summary>Client API version.</summary>
        public string ApiVersion => throw new NotImplementedException();

        /// <summary>Gets or sets the preferred language for the response.</summary>
        public string AcceptLanguage
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running
        /// Operations. Default value is 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated
        /// and included in each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
