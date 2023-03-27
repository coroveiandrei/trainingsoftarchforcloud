## Step 1 Create Azure Subcription

If you don't have an active Azure Subscription, you can create one at:
https://azure.microsoft.com/en-us/free/

Connect to portal.azure.com and create a new resource group called rg_arc_[yournameinitials]

## Step 2 Deploy Storage from Bicep template

1. Open up visual studio code
2. Open up folder in vs code C:\work\softwarearchforcloud\infracode
3. In storageparams.json, line 8, replace the name of the storage account with: arc[yourinitials]stor 
4. In VSCode terminal, run the commands:

az login

az deployment group what-if --resource-group  rg_arc_[yournameinitials] --template-file 1storage.bicep --parameters .\config\storageparams.json
This command will only show you what happens in case of a deployment

Now create the actual resources

az deployment group create  --resource-group  rg_arc_[yournameinitials] --template-file 1storage.bicep --parameters .\config\storageparams.json

