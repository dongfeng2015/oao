# Cloud Deployment Guide

This guide provides instructions for deploying the AccountOpening Blazor application to various cloud platforms.

## Common Issues and Solutions

### Issue: "AccountOpening.sln not found" Error
This typically occurs when cloud build systems handle file paths differently than local Docker builds.

**Solution Options:**

1. **Use the main Dockerfile** (recommended for most platforms)
   - Uses `*.csproj` wildcards instead of specific file names
   - Doesn't depend on solution files
   - Better caching with project file separation

2. **Use Dockerfile.simple** for minimal cloud deployments
   - Simplest possible Dockerfile
   - Single-stage build process
   - No solution file dependencies

3. **Use Dockerfile.cloud** for enterprise cloud platforms
   - Multi-stage build with explicit commands
   - Better security with non-root user
   - Verbose logging for debugging

## Platform-Specific Instructions

### Azure Container Apps / Azure App Service
```bash
# Use the main Dockerfile
az containerapp create \
  --name account-opening \
  --resource-group your-rg \
  --environment your-env \
  --image your-registry/account-opening:latest \
  --target-port 8080
```

### Google Cloud Run
```bash
# Build and deploy
gcloud run deploy account-opening \
  --source . \
  --platform managed \
  --region us-central1 \
  --allow-unauthenticated \
  --port 8080
```

### AWS App Runner / ECS
```bash
# Use Dockerfile.cloud for better compatibility
docker build -f Dockerfile.cloud -t account-opening .
```

### Heroku
Create a `heroku.yml` file:
```yaml
build:
  docker:
    web: Dockerfile.simple
run:
  web: dotnet AccountOpening.dll
```

### Railway
```bash
# Railway typically works well with the main Dockerfile
railway up
```

## Environment Variables for Production

Set these environment variables in your cloud platform:
```
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:8080
ALLOY_API_SECRET=your-secret-here
ALLOY_WORKFLOW_TOKEN=your-token-here
```

## Troubleshooting

### If build fails with file not found errors:
1. Try `Dockerfile.simple` first
2. Check that all required files are in the build context
3. Verify .dockerignore isn't excluding necessary files

### If the app starts but doesn't work:
1. Check environment variables are set correctly
2. Verify the port mapping (8080)
3. Check health endpoint: `/health`

### For debugging build issues:
Add `--verbosity diagnostic` to dotnet commands in Dockerfile temporarily.
