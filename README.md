## Test Plans

* Regression tests
  * Test RT1
    * Setup
      * Set Google Drive preferences to Syncing Mirror, StreamLoc DriveLetter
    * Checks
      * Check RT1-C1: Does Google Drive appear under plain "Drives" in sidebar or home?
        * Expected: No
        * Actual: 
      * Check RT1-C2: Does Google Drive appear exactly once under "Cloud Drives"?
        * Expected: Yes
        * Actual: 
      * Check RT1-C3: Does clicking on Google Drive open "My Drive" directly?
        * Expected: Yes
        * Actual: 
      * Check RT1-C4: Does clicking on Google Drive open the correct file system path for the settings configuration?
        * Expected: Yes
        * Actual: 
  * Test RT2
    * Setup
      * Set Google Drive preferences to Syncing Mirror, StreamLoc Folder
    * Checks
      * Check RT2-C1: Does Google Drive appear under plain "Drives" in sidebar or home?
        * Expected: No
        * Actual: 
      * Check RT2-C2: Does Google Drive appear exactly once under "Cloud Drives"?
        * Expected: Yes
        * Actual: 
      * Check RT2-C3: Does clicking on Google Drive open "My Drive" directly?
        * Expected: Yes
        * Actual: 
      * Check RT2-C4: Does clicking on Google Drive open the correct file system path for the settings configuration?
        * Expected: Yes
        * Actual: 
  * Test RT3
    * Setup
      * Set Google Drive preferences to Syncing Stream, StreamLoc Folder
    * Checks
      * Check RT3-C1: Does Google Drive appear under plain "Drives" in sidebar or home?
        * Expected: No
        * Actual: 
      * Check RT3-C2: Does Google Drive appear exactly once under "Cloud Drives"?
        * Expected: Yes
        * Actual: 
      * Check RT3-C3: Does clicking on Google Drive open "My Drive" directly?
        * Expected: Yes
        * Actual: 
      * Check RT3-C4: Does clicking on Google Drive open the correct file system path for the settings configuration?
        * Expected: Yes
        * Actual: 
  * Test R4
    * Setup
      * Set Google Drive preferences to Syncing Stream, StreamLoc DriveLetter
    * Checks
      * Check RT4-C1: Does Google Drive appear under plain "Drives" in sidebar or home?
        * Expected: No
        * Actual: 
      * Check RT4-C2: Does Google Drive appear exactly once under "Cloud Drives"?
        * Expected: Yes
        * Actual: 
      * Check RT4-C3: Does clicking on Google Drive open "My Drive" directly?
        * Expected: Yes
        * Actual: 
      * Check RT4-C4: Does clicking on Google Drive open the correct file system path for the settings configuration?
        * Expected: Yes
        * Actual: 
* Bugfix tests
  * Test BFT1
    * Summary
      * Confirm that a Google Drive `drive` has "Google Drive" as its drive label (and is therefore skipped by the CDFI)
    * Setup
      * Set Google Drive preferences to "Syncing set to Stream, Stream Location set to Drive Letter" with drive letter G.
      * Run Files with debugger.
      * Track the `driveLabel` local variable for each iteration of the `foreach` in `StorageDevicesService.GetDrivesAsync`.
    * Checks   
      * Check BFT1-C1: Does `driveLabel` for the `drive` whose `Name` is "G:\" equal "Google Drive"?
        * Expected: Yes
        * Actual:
  * Test BFT2
    * Summary
      * Confirm that a non-Google Drive `drive` that has "G:\" as its path (which is what KremmenUK's dashcam drive was) does not have "Google Drive" as its drive label (and is therefore *not* skipped by the CDFI)
    * Setup 1
      * Switch to main branch.
      * Set Google Drive preferences to "Syncing set to Stream, Stream Location set to Drive Letter" with drive letter G.
      * Stop Google Drive process.
      * Plug in a flash drive and set its drive letter to G.
      * Run Files with debugger.
      * Track what `GoogleDriveCloudDetector.GetRegistryBasePath` finds in the registry.
      * Track the `driveLabel` local variable for each iteration of the `foreach` in `StorageDevicesService.GetDrivesAsync`.
    * Checks 1 (these should show that the changes made to my machine's configuration in Setup 1 reproduce KremmenUK's issue)
      * Check BFT2-C1: Do we see "G" as the mount point?
        * Expected: Yes
        * Actual:
      * Check BFT2-C2: Does the `driveLabel` for the `drive` whose `Name` is "G:\" equal "Google Drive"?
        * Expected: No
        * Actual:
      * Check BFT2-C3: Does the flash drive on drive letter G appear in the plain "Drives" sections in the app?
        * Expected: No
        * Actual:
    * Setup 2
      * Switch to BugGoogleDriveNotRecognized branch.
    * Checks 2 (these should show that the changes made to the Files code in this PR branch solve KremmenUK's issue)
      * Check BFT2-C4: Does the flash drive on drive letter G appear in the plain "Drives" sections in the app?
        * Expected: Yes
        * Actual:

