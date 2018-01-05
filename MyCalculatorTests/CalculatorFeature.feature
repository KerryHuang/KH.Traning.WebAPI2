Feature: 透過Calculator類別進行數值計算
 In order to 進行Add運算
 As a Calculator呼叫者
 I want to 驗證兩個數值Add()後的回傳的總數

@Calculator
Scenario: 兩個正整數相加
 Given 我輸入第一個整數5到計算機
 And 我輸入第二個整數5到計算機
 When 呼叫Calculator的Add的int多載方法
 Then 應該得到整數結果為10

Scenario: 兩個浮點數相加
 Given 我輸入第一個浮點數5.4到計算機
 And 我輸入第二個浮點數5.4到計算機
 When 呼叫Calculator的Add的double多載方法
 Then 應該得到浮點數結果為10.8
