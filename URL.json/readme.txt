测试例子：(可以通过浏览器直接请求以下URL)
1. 
case: http://localhost:8081/Service1.svc/student/1?format=xml
result: 返回xml格式数据

2. 
case: http://localhost:8081/Service1.svc/student/1?format=json
result: 返回json格式数据

3. 
case: http://localhost:8081/Service1.svc/student/1
result: 返回xml格式数据

4. 
case: http://localhost:8081/Service1.svc/student/1.json
result: 返回json格式数据
原理：把1.json请求重定向为:1?format=json

