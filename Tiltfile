load('ext://namespace', 'namespace_create', 'namespace_inject')

namespace_create('thegreatneuron')

serviceAspNetCorePath = './src/services/aspnetcore/'
uisReactPath = './src/uis/react/'
helmPath = './infrastructure/k8s/helm/'

services = {
    'client': uisReactPath+'client/',
    'article': serviceAspNetCorePath+'article/',
}

def dockerSetup(name, path):
  composedName='thegreatneuron-'+name
  docker_build(composedName, context=serviceAspNetCorePath, dockerfile=path+'dockerfile.dev')

def helmSetup(name, hasDefaultValues = True):
  path = helmPath+name+'/'
  local('helm dependency update '+path)

  values=[]
  if(hasDefaultValues):
    values=[path+'values.dev.yaml']

  k8s_yaml(helm(path, name=name, namespace='thegreatneuron', values=values))


#for name, path in services.items():
#  dockerSetup(name, path)
docker_build('thegreatneuron-article', context='./src/services/aspnetcore/', dockerfile='./src/services/aspnetcore/article/dockerfile.dev', live_update=[
  sync('./src/services/aspnetcore/article/', '/app'),
])
docker_build('thegreatneuron-client', context='./src/uis/react/client/', dockerfile='./src/uis/react/client/dockerfile.dev', live_update=[
  sync('./src/uis/react/client/', '/app'),
  run('cd /app && npm install', trigger='./src/uis/react/client/package.json')
])


helmSetup('ingress', False)
for ds in services:
  helmSetup(ds)

k8s_resource(objects=['ingress-srv:ingress'], new_name='ingress')
k8s_resource('client', port_forwards='8000:3000')
k8s_resource('article', port_forwards='8003:5000')