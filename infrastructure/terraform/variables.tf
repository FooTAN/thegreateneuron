variable "build_number" {
  type        = string
  description = "Latest Build"
}

variable "tfstate_resource_group_name" {
  type        = string
  description = "resource group name"
}

variable "tfstate_storage_account_name" {
  type        = string
  description = "storage account name"
}

variable "tfstate_container_name" {
  type        = string
  description = "container name"
}

variable "cluster_node_count" {
  type        = string
  description = "node count"
}

variable "cluster_vm_size" {
  type        = string
  description = "vm size"
}

variable "cluster_name" {
  type        = string
  description = "vm size"
}

variable "cluster_dns_prefix" {
  type        = string
  description = "vm size"
}

variable "rg_name" {
  type        = string
  description = "resource group name"
}

variable "rg_location" {
  type        = string
  description = "resource group location"
}
