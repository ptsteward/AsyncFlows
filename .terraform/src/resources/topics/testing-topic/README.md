## Modules

| Name | Module | Source | Version |
|------|------|--------|---------|
| cf-testtopic | ./topic.tf | ../../../../modules/kafka-topic/ | n/a |
| cf-testtopic-sa | ./topic-acl.tf | ../../../../sa/ | n/a |
| cf-testtopic-acl | ./topic-acl.tf | ../../../../modules/kafka-acl-topic-read-write/ | n/a |

## Resources

| Name | Type |
|------|------|
| [confluent_kafka_topic.topic](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/resources/confluent_kafka_topic) | resource |
| [confluent_kafka_cluster.public](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/data-sources/confluent_kafka_cluster) | data source |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| app\_name | Application for which the topic will be provisioned | `string` | n/a | yes |
| confluent\_cluster\_credentials | Kafka Cluster Secrets | `map(string)` | n/a | yes |
| confluent\_config | Environment and Cluster Details | `map(string)` | n/a | yes |
| namespace | Domain name in which the topic will be provisioned | `string` | n/a | yes |
| topic\_cleanup\_policy | Multiple messages with the same key will exists in a the topic | `string` | n/a | yes |
| topic\_extra\_config | Topic config values that are not defined through individual variables. Users can pass any config key/value pair here. If a config defined through a variable is also defined here, the variable value takes precedence. | `map(string)` | `{}` | no |
| topic\_max\_message\_size\_bytes | Max message size for the message in the topic in bytes | `string` | n/a | yes |
| topic\_min\_insync\_replicas | Insync replicas for topics | `number` | n/a | yes |
| topic\_name | Name of the Kafka topic | `string` | n/a | yes |
| topic\_partitions\_count | No of partitons for the Kafka topic | `string` | n/a | yes |
| topic\_retention\_time\_ms | Time in ms for message to be retained for a day in ms | `string` | n/a | yes |
| topic\_scope | Scope for the Kafka topic | `string` | n/a | yes |

## Outputs

| Name | Description |
|------|-------------|
| topic\_name | Name of the Kafka topic provisioned |
| topic\_sa\_id | Id of the Service Account provisioned |
| topic\_sa\_key | Key of the Service Account provisioned |
| topic\_acl\_pattern\_type | The pattern set for ACL on the Kafka resource |