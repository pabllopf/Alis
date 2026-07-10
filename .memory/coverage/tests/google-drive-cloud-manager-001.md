## COVERAGE TEST

### File Under Test
GoogleDriveCloudManager.cs

### Test File
GoogleDriveCloudManagerCoverageTest.cs

### Pattern
Internal constructor injection of DriveService for testing cloud manager exception paths.

### Technique
- Added `internal GoogleDriveCloudManager(Context context, DriveService driveService)` constructor
- Create `DriveService` with minimal `BaseClientService.Initializer()` - no real credentials needed
- API calls throw naturally due to missing authentication, exercising catch blocks
- Verify exceptions propagate correctly (not masked by InvalidOperationException preconditions)

### Tests (23)
1. Constructor_WithDriveService_IsInitializedTrue
2. Constructor_WithoutDriveService_IsInitializedFalse
3. UploadFileAsync_WithNonExistentFile_ThrowsFileNotFoundException
4. UploadFileAsync_WithNonExistentFileAndPathNormalized_ThrowsFileNotFoundException
5. UploadFileAsync_WithLocalFilePathNull_ThrowsFileNotFoundException
6. UploadFileAsync_WhenApiThrows_ThrowsException
7. DownloadFileAsync_WhenApiThrows_ThrowsException
8. DownloadFileAsync_WithPathNormalized_WhenApiThrows_ThrowsException
9. ListFilesAsync_WhenApiThrows_ThrowsException
10. ListFilesAsync_WithEmptyPath_DefaultsToRoot
11. ListFilesAsync_WithNullPath_DefaultsToRoot
12. ListFilesAsync_WithPathNoLeadingSlash_NormalizesPath
13. DeleteAsync_WhenApiThrows_ThrowsException
14. DeleteAsync_WithPathNormalized_WhenApiThrows_ThrowsException
15. GetMetadataAsync_WhenApiThrows_ThrowsException
16. GetMetadataAsync_WithPathNormalized_WhenApiThrows_ThrowsException
17. Dispose_WithDriveService_ShouldNotThrow
18. Dispose_MultipleCalls_ShouldNotThrow
19. OnDestroy_WithDriveService_ShouldNotThrow
20. OnDestroy_ThenDispose_ShouldNotThrow
21. Dispose_ThenOnDestroy_ShouldNotThrow
22. IsInitialized_AfterDispose_ReturnsFalse
23. IsInitialized_AfterOnDestroy_ReturnsFalse
