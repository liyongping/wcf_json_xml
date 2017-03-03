GetStudent测试例子：
1. (可以通过浏览器直接请求以下URL)
case: http://localhost:8080/Service1.svc/student/1
result: 返回xml格式数据(查看页面源码)
说明：
    通过Fiddler2或HTTP Analyzer工具，捕获请求http://localhost:8080/Service1.svc/student/1发出的报文，可以发现（用chrome访问，具体根据你自己捕获的HTTP报文，注意Accept）：
	    Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
	可以发现，默认返回顺序是：text/html-->application/xhtml+xml-->application/xml
2. 
case: http://localhost:8080/Service1.svc/student/1
HTTP HEADER:
    Accept: application/xml;q=0.9,*/*;q=0.8
result: 返回xml格式数据

3. 
case: http://localhost:8080/Service1.svc/student/1
HTTP HEADER:
    Accept: application/json;q=0.9,*/*;q=0.8
result: 返回json格式数据