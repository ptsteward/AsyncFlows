#
# Producer : sched-primesched-zipcapability-sa-[env]
#
module "cf-testtopic-sa" {
  source = "../../../../modules/sa/"

  # Your values go here
  namespace   = "cf"
  app_name    = "corestreams"
  description = "Service account for 'cf-testtopic'"

  # Do not change the below values
  confluent_config = var.confluent_config
}

#
# Topic ACL
#
module "cf-testtopic-acl" {
  source = "../../../../modules/kafka-acl-topic-read-write/"

  # Update the below values accordingly
  resource_name = module.cf-testtopic.topic_details.topic_name
  principal     = "${module.cf-testtopic.id}"

  # Do not change the below values
  confluent_config               = var.confluent_config
  confluent_cluster_credentials  = var.CONFLUENT_CLUSTER_CREDENTIALS
}

#
# Outputs : Producer Details
#
output "sa_cf-testtopic_id" {
  value = module.cf-testtopic-sa.id
}

output "sa_cf-testtopic_key" {
  value = module.cf-testtopic-sa.key
}

output "acl_cf-testtopic_acl_pattern_type_topic" {
  value = module.cf-testtopic-acl.acl_pattern_type
}
