#
# Environment and Cluster Details
#
variable "confluent_config" {
  type = map(string)
}


#
# Service Account details
#
variable "namespace" {
  type        = string
  description = "Namespace for the service account to be provisioned"

  validation {
    condition     = length(var.namespace) > 1
    error_message = "The namespace specified is not valid"
  }
}

variable "app_name" {
  type        = string
  description = "Appname for the service account to be provisioned"

  validation {
    condition     = length(var.app_name) > 1
    error_message = "The app name specified is not valid"
  }
}


variable "description" {
  type        = string
  description = "Description for the service account to be provisioned"

  validation {
    condition     = length(var.description) > 1
    error_message = "The service name description specified is not valid"
  }
}


