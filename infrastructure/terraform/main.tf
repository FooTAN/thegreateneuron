terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=2.78.0"
    }
  }

  backend "azurerm" {
    resource_group_name = var.tfstate_resource_group_name
    storage_account_name = var.tfstate_storage_account_name
    container_name = var.tfstate_container_name
    key = "terraform.tfstate"
  }
  
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = var.rg_name
  location = var.rg_location
}

resource "azurerm_kubernetes_cluster" "cluster" {
  name                = var.cluster_name
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  dns_prefix          = var.cluster_dns_prefix

  default_node_pool {
    name       = "default"
    node_count = var.cluster_node_count
    vm_size    = var.cluster_vm_size
  }

  identity {
    type = "SystemAssigned"
  }
}