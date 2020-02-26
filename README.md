# azureFunctions

test with Invoke Web Request command at power shell
iwr -Method Post `-Uri http://localhost:{port #}/api/onPaymentReceived`

- Headers @{ "Content-Type="application/json" }
- Body '{}'

to run
func host start

In the terminal window or from a command prompt, run the following command to create the project and local Git repository:
func init MyFunctionProj

To create new function:
func new {project name}

To create a queue-triggered function in a single command, run:

func new --template "Queue Trigger" --name QueueTriggerJS

added package reference to allow for storage bindings
WebJobs.Extensions.Storage

to check at \_ Portal
in storage account
see storage explorer
Queues
