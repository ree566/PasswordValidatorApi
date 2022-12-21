# PasswordValidatorApi

## General info
This project is simple password validator api.

## Setup
Initialize chain manager with `ChainFailOnErrorOrNot:bool`
```
ChainManager<string> passwordValidateChain = new ChainManager<string>([ChainFailOnErrorOrNot]);
```

Call AppendHandlerToChain to regist the custom chain 
```
passwordValidateChain.AppendHandlerToChain(new IChainHandler<string>[]
{
    new CharacterLengthFilterValidationHandler(1, 10),
    new ContainsAtLeastOneDigitsValidationHandler(),
    new ContainsAtLeastOneLowerCaseValidationHandler(),
    new LowerCaseAndDigitsOnlyValidationHandler(),
    new NotContainAdjacentSameSequenceValidationHandler()
});
```

Get the chain processing result, error will be catched into exceptions list
```
List<ChainHandlerException> exceptions;
HandlerResult result = passwordValidateChain.ProcessRequest(item, out exceptions);
```

HandlerResult.class
| Name                   | description                                            |
| :-----:                | :---:                                                  | 
| CHAIN_DATA_HANDLED     | Chains process without exceptions                      | 
| CHAIN_DATA_NOT_HANDLED | Any chain throws exception will get not handled status |
