#
# Providers
#
terraform {
  required_providers {
    confluent = {
      source  = "confluentinc/confluent"
      version = "1.0.0"
    }

    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.10.0"
    }
  }

  backend "azurerm" {}

  required_version = ">= 1.1.0"
}


provider "confluent" {}

provider "azurerm" {
  features {}
}