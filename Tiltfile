load('ext://namespace', 'namespace_create', 'namespace_inject')

namespace_create('thegreatneuron')

services = [
    'client',
    'article',
    'admin'
]

def dockerSetup(name):
  composedName='thegreatneuron-'+name
  path='./src/services/'+name+'/'
  docker_build(composedName, path, dockerfile=path+'dockerfile.dev')

def helmSetup(name, hasDefaultValues = True):
  path = './infrastructure/k8s/helm/'+name+'/'
  local('helm dependency update '+path)

  values=[]
  if(hasDefaultValues):
    values=[path+'values.dev.yaml']

  k8s_yaml(helm(path, name=name, namespace='thegreatneuron', values=values))


for ds in services:
  dockerSetup(ds)

helmSetup('ingress', False)
for ds in services:
  helmSetup(ds)

k8s_resource(objects=['ingress-srv:ingress'], new_name='ingress')
k8s_resource('client', port_forwards='8000:3000')
k8s_resource('article', port_forwards='8003:8003')
k8s_resource('admin', port_forwards='8001:3000')