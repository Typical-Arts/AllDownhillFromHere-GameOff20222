# unity_template
A template repository for unity project

Secrets required for CI:

Unity:
-  UNITY_LICENSE: ${{ secrets.UNITY_LICENSE }} // generated from licence file workflow
-  UNITY_EMAIL: ${{ secrets.UNITY_EMAIL }} 
-  UNITY_PASSWORD: ${{ secrets.UNITY_PASSWORD }}

GCS:
-  workload_identity_provider: ${{ secrets.WORKLOAD_ID_PROVIDER }}
-  service_account: ${{ secrets.GCS_SERVICE_ACCOUNT }}
