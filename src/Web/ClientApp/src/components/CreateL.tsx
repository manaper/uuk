import React, { useState, useEffect } from "react";
import { Form, Input, Button, Select, Upload, Checkbox, message } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import { mockBanks, mockOrganizations } from "./Constants";

const { Option } = Select;

const CompanyForm: React.FC = () => {
  const [formType, setFormType] = useState<string>("");
  const [form] = Form.useForm();
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    form.resetFields();
  }, [formType]);

  const handleFinish = async (values: any) => {
    setLoading(true);
    try {
      if (formType === "Bank") {
        await submitData(values);
        message.success("Form submitted successfully");
      } else {
        setFormType("Bank");
      }
    } catch (error) {
      message.error("Error submitting form");
    } finally {
      setLoading(false);
    }
  };

  const autoFillLLC = (inn: string) => {
    if (inn.length >= 4) {
      const org = mockOrganizations[inn];
      if (org) {
        form.setFieldsValue({
          fullName: org.fullName,
          shortName: org.shortName,
          registrationDate: org.registrationDate,
          ogrn: org.ogrn,
        });
      }
    }
  };

  const autoFillBank = (bik: string) => {
    const bank = mockBanks[bik];
    if (bank) {
      form.setFieldsValue({
        branchName: bank.branchName,
        accountNumber: bank.accountNumber,
        correspondentAccount: bank.correspondentAccount,
      });
    }
  };

  const submitData = async (data: any) => {
    try {
    } catch (error) {
      console.error("Error submitting form:", error);
    }
  };

  return (
    <div>
      <h1>Заполнение анкеты</h1>
      <Select
        onChange={(value) => setFormType(value)}
        placeholder="Выберите вид деятельности"
        style={{ width: "100%", marginBottom: "20px" }}
      >
        <Option value="IP">Индивидуальный предприниматель (ИП)</Option>
        <Option value="LLC">
          Общество с ограниченной ответственностью (ООО)
        </Option>
      </Select>

      <Form
        form={form}
        layout="vertical"
        onFinish={handleFinish}
        initialValues={{ noLeaseAgreement: false }}
      >
        {(formType === "IP" || formType === "LLC") && (
          <>
            <Form.Item
              name="inn"
              label="ИНН"
              rules={[{ required: true, message: "ИНН обязателен" }]}
            >
              <Input onChange={(e) => autoFillLLC(e.target.value)} />
            </Form.Item>
          </>
        )}

        {formType === "IP" && (
          <>
            <Form.Item
              name="innScan"
              label="Скан ИНН"
              rules={[{ required: true, message: "Скан ИНН обязателен" }]}
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item
              name="ogrnip"
              label="ОГРНИП"
              rules={[{ required: true, message: "ОГРНИП обязателен" }]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="ogrnipScan"
              label="Скан ОГРНИП"
              rules={[{ required: true, message: "Скан ОГРНИП обязателен" }]}
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item
              name="registrationDate"
              label="Дата регистрации"
              rules={[
                { required: true, message: "Дата регистрации обязательна" },
              ]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="egripScan"
              label="Скан выписки из ЕГРИП"
              rules={[
                { required: true, message: "Скан выписки из ЕГРИП обязателен" },
              ]}
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item
              name="leaseAgreementScan"
              label="Скан договора аренды помещения (офиса)"
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item name="noLeaseAgreement" valuePropName="checked">
              <Checkbox>Нет договора</Checkbox>
            </Form.Item>
          </>
        )}

        {formType === "LLC" && (
          <>
            <Form.Item
              name="innScan"
              label="Скан ИНН"
              rules={[{ required: false, message: "Скан ИНН обязателен" }]}
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item
              name="ogrn"
              label="ОГРН"
              rules={[{ required: true, message: "ОГРН обязателен" }]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="ogrnScan"
              label="Скан ОГРН"
              rules={[{ required: false, message: "Скан ОГРН обязателен" }]}
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item
              name="fullName"
              label="Наименование полное"
              rules={[
                { required: true, message: "Наименование полное обязательно" },
              ]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="shortName"
              label="Наименование сокращенное"
              rules={[
                {
                  required: true,
                  message: "Наименование сокращенное обязательно",
                },
              ]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="registrationDate"
              label="Дата регистрации"
              rules={[
                { required: true, message: "Дата регистрации обязательна" },
              ]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="egripScan"
              label="Скан выписки из ЕГРИП"
              rules={[
                {
                  required: false,
                  message: "Скан выписки из ЕГРИП обязателен",
                },
              ]}
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item
              name="leaseAgreementScan"
              label="Скан договора аренды помещения (офиса)"
            >
              <Upload beforeUpload={() => false}>
                <Button icon={<UploadOutlined />}>Загрузить</Button>
              </Upload>
            </Form.Item>
            <Form.Item name="noLeaseAgreement" valuePropName="checked">
              <Checkbox>Нет договора</Checkbox>
            </Form.Item>
          </>
        )}

        {formType === "Bank" && (
          <>
            <Form.Item
              name="bik"
              label="БИК"
              rules={[{ required: true, message: "БИК обязателен" }]}
            >
              <Input onBlur={(e) => autoFillBank(e.target.value)} />
            </Form.Item>
            <Form.Item
              name="branchName"
              label="Название филиала банка"
              rules={[
                {
                  required: true,
                  message: "Название филиала банка обязательно",
                },
              ]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="accountNumber"
              label="Расчетный счет"
              rules={[{ required: true, message: "Расчетный счет обязателен" }]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              name="correspondentAccount"
              label="Корреспондентский счет"
              rules={[
                {
                  required: true,
                  message: "Корреспондентский счет обязателен",
                },
              ]}
            >
              <Input />
            </Form.Item>
          </>
        )}

        <Form.Item>
          <Button type="primary" htmlType="submit" loading={loading}>
            {formType === "Bank" ? "Отправить" : "Далее"}
          </Button>
        </Form.Item>
      </Form>
    </div>
  );
};

export default CompanyForm;
