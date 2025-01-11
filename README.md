## Test Plans

* Regression tests
  * Test R1
    * Setup
      * Set Google Drive preferences to Syncing Mirror, StreamLoc DriveLetter
    * Checks
      * R1a: Does Google Drive appear under plain "Drives" in sidebar or home?
        * Expected: No
        * Actual: 
      * R1b: Does Google Drive appear exactly once under "Cloud Drives"?
        * Expected: Yes
        * Actual: 
      * R1c: Does clicking on Google Drive open "My Drive" directly?
        * Expected: Yes
        * Actual: 
      * R1d: Does clicking on Google Drive open the correct file system path for the settings configuration?
        * Expected: Yes
        * Actual: 
  * Test R2
    * Setup
      * Set Google Drive preferences to Syncing Mirror, StreamLoc Folder
    * Checks
      * Confirm that Google Drive does not appear under plain "Drives"
      * Confirm that Google Drive appears exactly once under "Cloud Drives"
      * Confirm that clicking on Google Drive opens "My Drive" directly
      * Confirm that clicking on Google Drive opens the correct file system path for the settings configuration
  * Test R3
    * Setup
      * Set Google Drive preferences to Syncing Stream, StreamLoc Folder
    * Checks
      * Confirm that Google Drive does not appear under plain "Drives"
      * Confirm that Google Drive appears exactly once under "Cloud Drives"
      * Confirm that clicking on Google Drive opens "My Drive" directly
      * Confirm that clicking on Google Drive opens the correct file system path for the settings configuration
  * Test R4
    * Setup
      * Set Google Drive preferences to Syncing Stream, StreamLoc DriveLetter
    * Checks
      * Confirm that Google Drive does not appear under plain "Drives"
      * Confirm that Google Drive appears exactly once under "Cloud Drives"
      * Confirm that clicking on Google Drive opens "My Drive" directly
      * Confirm that clicking on Google Drive opens the correct file system path for the settings configuration
* Bugfix tests
  * Test BF1
    * Summary
      * Confirm that a Google Drive `drive` has "Google Drive" as its drive label (and is therefore skipped by the CDFI)
    * Setup
      * Set Google Drive preferences to "Syncing set to Stream, Stream Location set to Drive Letter" with drive letter G.
      * Run Files with debugger.
    * Checks   Check what drive labels get stored in `driveLabel` for each iteration of the `foreach` in `StorageDevicesService.GetDrivesAsync`.
            We want the `driveLabel` for the `drive` whose `Name` is "G:\" to be "Google Drive".

    Confirm that a non-Google Drive `drive` that has "G:\" as its path (which is what KremmenUK's dashcam drive was) does not have "Google Drive" as its drive label (and is therefore *not* skipped by the CDFI)
        Set Google Drive preferences to "Syncing set to Stream, Stream Location set to Drive Letter" with drive letter G.
        Stop Google Drive process.
        Plug in a flash drive and set its drive letter to G.
        Run Files with debugger.
        Check what `GoogleDriveCloudDetector.GetRegistryBasePath` finds in the registry.
            We want to see "G" as the mount point.
        Check what drive labels get stored in `driveLabel` for each iteration of the `foreach` in `StorageDevicesService.GetDrivesAsync`.
            We want the `driveLabel` for the `drive` whose `Name` is "G:\" to *not* be "Google Drive".
        Check the plain "Drives" sections in the app.
            We want to see the flash drive on G.
        Switch to main branch.
        Run Files.
        Check the plain "Drives" sections in the app.
            We want to *not* see the flash drive on G (this would reproduce KremmenUK's issue).

