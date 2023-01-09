## Modules

No modules.

## Resources

| Name | Type |
|------|------|
| [confluent_api_key.sa-account-kafka-api-key](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/resources/confluent_api_key) | resource |
| [confluent_service_account.topic](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/resources/confluent_service_account) | resource |
| [confluent_kafka_cluster.public](https://registry.terraform.io/providers/confluentinc/confluent/latest/docs/data-sources/confluent_kafka_cluster) | data source |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| app\_name | Appname for the service account to be provisioned | `string` | n/a | yes |
| confluent\_config | Environment and Cluster Details | `map(string)` | n/a | yes |
| description | Description for the service account to be provisioned | `string` | n/a | yes |
| namespace | Namespace for the service account to be provisioned | `string` | n/a | yes |

## Outputs

| Name | Description |
|------|-------------|
| id | n/a |
| key | n/a |
| name | Service account details |
| secret | n/a |
