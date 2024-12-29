# Database Setup
function dbs {
    $migrations_dir = ".\TestGoogleDrive\Migrations"
    $project_fil = ".\TestGoogleDrive\TestGoogleDrive.csproj"

    if (Test-Path $migrations_dir) {
        Remove-Item -r -fo $migrations_dir
    }

    dotnet ef database update 0 --project $project_fil
    dotnet ef migrations add InitialCreate --project $project_fil
    dotnet ef database update --project $project_fil
}
