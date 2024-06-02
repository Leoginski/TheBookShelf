# TheBookShelf

### Running Locally
With the database up and running, check the ConnectionString and apply the migrations:

Update the Database:
```
dotnet ef database update -s /TheBookShelf.Server/TheBookShelf.Api.csproj -v -c DataContext
```

### Infrastructure
Requirements:
* Azure Account
* AzureCLI
* Terraform
* Kubectl

AzureCLI Login
```
az login
```

AzureCLI Creating ActiveDirectory
```
az ad sp create-for-rbac --skip-assignment
```

Copy the resulting object, example:
```
{
  "appId": "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
  "displayName": "azure-cli-2024-06-02-18-19-00",
  "name": "http://azure-cli-2024-06-02-18-19-00",
  "password": "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
  "tenant": "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
}
```

Update your terraform.tfvars file with appId and Password
```
# terraform.tfvars
appId    = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
password = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
```

Initialize Terraform
```
terraform init
```

Provision the AKS cluster
```
terraform apply
```

Configure kubectl
```
az aks get-credentials --resource-group $(terraform output -raw resource_group_name) --name $(terraform output -raw kubernetes_cluster_name)
```

If you want to... Access the Kubernetes Dashboard
```
az aks browse --resource-group $(terraform output -raw resource_group_name) --name $(terraform output -raw kubernetes_cluster_name)
```

### Pre-Deployment Step (now it's optional, the image is already published)
Build Docker Image:
```
docker build -t leoginski/thebookshelfapi:1.0.0 -f TheBookShelf.Server/Dockerfile .
```

Publishing Docker Image, you can replace the image repository of your choice (using DockerHub here because it's free):
```
docker push leoginski/thebookshelfapi:1.0.0
```

### Deploying
Now you can deploy to Kubernetes using the provided yml's for the API:
(if using windows replace the forward slash '/' for the backward slash '\\'.
* Application
```
kubectl apply -f ./deploy.yml
```
* Load Balancer
```
kubectl apply -f ./service.yml
```

Don't forget to destroy everything when you're done
```
terraform destroy
```