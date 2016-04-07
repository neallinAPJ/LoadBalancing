程序功能：负载均衡下的缓存清理
在config文件中的loadBalancing节点可配置缓存清理所需要的信息。
可配置项如下：
loadBalancing：用来配置缓存清理所需要的信息，有且只有一个。

server：
	该节点主要用来配置负载均衡的服务器所需的信息，可配置多个server节点，必须被包含在loadBalancing节点里面，可配置如下属性
	1.index：该元素必需存在且唯一（相同的server节点,不能有重复的index的值），为该节点的索引属性，值：可输入任意数字；
	2.ip：该元素必需存在，值：服务器的IP；
	3.requestUrl：该元素必需存在，值：执行缓存清理操作的Url地址；
	4.loginUrl:配置网站登录的Url