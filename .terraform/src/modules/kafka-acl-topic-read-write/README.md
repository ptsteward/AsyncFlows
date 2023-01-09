## Modules

No modules.

## Resources

| Name | Type |
|------|------|
| [confluent_kafka_acl.describe](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/resources/confluent_kafka_acl#operation) | resource |
| [confluent_kafka_acl.describe-configs](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/resources/confluent_kafka_acl#operation) | resource |
| [confluent_kafka_acl.write](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/resources/confluent_kafka_acl#operation) | resource |
| [confluent_kafka_cluster.public](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/data-sources/confluent_kafka_cluster) | data source |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| confluent\_cluster\_credentials | Kafka Cluster Secrets | `map(string)` | n/a | yes |
| confluent\_config | Environment and Cluster Details | `map(string)` | n/a | yes |
| principal | Account for which ACL has to be applied | `string` | n/a | yes |
| resource\_name | Name for the resource on which ACL has to be applied | `string` | n/a | yes |

## Outputs

| Name | Description |
|------|-------------|
| acl\_pattern\_type | The pattern set for ACL on the Kafka resource |
| resource\_name | The name of the resource on which the ACL was applied |
