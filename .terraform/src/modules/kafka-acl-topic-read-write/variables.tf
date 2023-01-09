#
# Environment and Cluster Details
#
variable "confluent_config" {
  type = map(string)
}


#
# Kafka Cluster Secrets
#
variable "confluent_cluster_credentials" {
  type = map(string)
}


#
# ACL details
#
variable "resource_name" {
  type        = string
  description = "Name for the resource on which ACL has to be applied"

  validation {
    condition     = length(var.resource_name) > 1
    error_message = "The resource specified is not valid"
  }
}

variable "principal" {
  type        = string
  description = "Account for which ACL has to be applied"

  validation {
    condition     = length(var.principal) > 1
    error_message = "The specified principal is not valid"
  }
}     
