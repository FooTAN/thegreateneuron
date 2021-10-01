terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=2.78.0"
    }
  }

  backend "azurerm" {
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
    os_type = "Linux"
  }

  identity {
    type = "SystemAssigned"
  }

  addon_profile {
    http_application_routing {
      enabled = true
    }
# let us disable som addons, otherwise we'll automatically get unecessary provisioning
    aci_connector_linux {
      enabled = false
    }

    azure_policy {
      enabled = false
    }

    ingress_application_gateway {
      enabled = false
    }

    kube_dashboard {
      enabled = false
    }

    oms_agent {
      enabled = false
    }
  }
}
