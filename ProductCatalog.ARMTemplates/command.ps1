$ResourceGroupName = "DecnsoftEcom-rg"
$templateFile = "azuredeploy.json" 
$parameterFile="azuredeploy.parameters.json" 

New-AzResourceGroup `
  -Name $ResourceGroupName `
  -Location "East US"

 New-AzResourceGroupDeployment `
  -Name EComApp `
  -ResourceGroupName $ResourceGroupName `
  -TemplateFile $templateFile `
  -TemplateParameterFile $parameterFile
