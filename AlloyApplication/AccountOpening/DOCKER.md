# Account Opening Application - Docker Setup

## 🐳 Docker Support

This application includes full Docker support for both development and production environments.

## Quick Start

### 1. **Build and Run with Docker Compose**
```bash
# Build and start the application
docker-compose up --build

# Run in detached mode
docker-compose up -d --build

# View logs
docker-compose logs -f
```

### 2. **Access the Application**
- **Production**: http://localhost:8080
- **Development**: http://localhost:5000

## Configuration

### Environment Variables
Copy the example environment file and customize:
```bash
cp .env.example .env
# Edit .env with your actual Alloy API credentials
```

### Key Environment Variables:
- `ALLOY_API_KEY`: Your Alloy API key
- `ALLOY_BASE_URL`: Alloy API base URL (default: sandbox)
- `ASPNETCORE_ENVIRONMENT`: Application environment

## Docker Commands

### Build Image Only
```bash
docker build -t account-opening .
```

### Run Container Directly
```bash
docker run -p 8080:8080 \
  -e Alloy__ApiKey="your_api_key" \
  -e Alloy__BaseUrl="https://sandbox.alloy.co/v1/" \
  account-opening
```

### Development Mode
```bash
# Uses docker-compose.override.yml automatically
docker-compose up --build
```

### Production Mode
```bash
# Disable override file for production
docker-compose -f docker-compose.yml up --build
```

## Health Checks

The application includes health checks available at:
- **Health endpoint**: `/health`
- **Docker health check**: Runs every 30 seconds

## Troubleshooting

### View Container Logs
```bash
docker-compose logs accountopening
```

### Execute Commands in Container
```bash
docker-compose exec accountopening bash
```

### Rebuild Everything
```bash
docker-compose down
docker-compose build --no-cache
docker-compose up
```

## Production Deployment

1. **Set environment variables** in your production environment
2. **Use production compose file**: `docker-compose -f docker-compose.yml up -d`
3. **Configure reverse proxy** (nginx, traefik, etc.) if needed
4. **Set up monitoring** using the `/health` endpoint

## Security Notes

- Application runs as non-root user (appuser:1001)
- Secrets should be managed via environment variables
- Health checks enabled for container orchestration
- HTTPS redirection enabled in production
